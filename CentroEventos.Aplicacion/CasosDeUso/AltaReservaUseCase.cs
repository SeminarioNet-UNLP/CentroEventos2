using CentroEventos.Aplicaciones.Excepciones;
using CentroEventos.Aplicaciones.Validaciones;

public class AltaReservaUseCase
{
    private readonly IRepositorioReserva _repoReserva;
    private readonly IRepositorioPersona _repoPersona;
    private readonly IRepositorioEventoDeportivo _repoEventoDeportivo;
    private readonly IServicioAutorizacion _autorizador;
    private readonly ValidarReserva _validador;
    public AltaReservaUseCase(IRepositorioReserva repoReserva,
                              IRepositorioPersona repoPersona,
                              IRepositorioEventoDeportivo repoEventoDeportivo,
                              IServicioAutorizacion autorizador, ValidarReserva validador)
    {
        _repoReserva = repoReserva;
        _repoPersona = repoPersona;
        _repoEventoDeportivo = repoEventoDeportivo;
        _autorizador = autorizador;
        _validador = validador;
    }

    public void Ejecutar(Reserva reserva, Usuario usuario)
    {
        string mensajeError;
        if (!_autorizador.PoseeElPermiso(usuario, Permiso.Administrador))
        {
            throw new FalloAutorizacionException();
        }

        if (!_validador.ExistenPersonaYEvento(reserva.PersonaId, reserva.EventoDeportivoId, out mensajeError))
        {
            throw new EntidadNotFoundException(mensajeError);
        }

        if (!_validador.VerificarReservaExistente(reserva, out mensajeError))
        {
            throw new CupoExcedidoException(mensajeError);
        }

        if (!_validador.VerificarCupoDisponible(reserva.EventoDeportivoId, out mensajeError))
        {
            throw new DuplicadoException(mensajeError);
        }

        try
        {
            _repoReserva.AltaReserva(reserva);
        }
        catch
        {
            throw;
        }
    }
} 

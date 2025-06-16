using CentroEventos.Aplicaciones.Excepciones;
using CentroEventos.Aplicaciones.Validaciones;

public class ModificarReservaUseCase
{
    private readonly IRepositorioReserva _repoReserva;
    private readonly IRepositorioPersona _repoPersona;
    private readonly IRepositorioEventoDeportivo _repoEventoDeportivo;
    private readonly IServicioAutorizacion _autorizador;
    private readonly ValidarReserva _validador;
    public ModificarReservaUseCase(IRepositorioReserva repoReserva,
                                   IRepositorioPersona repoPersona,
                                   IRepositorioEventoDeportivo repoEventoDeportivo,
                                   IServicioAutorizacion autorizador,
                                   ValidarReserva validador)
    {
        _repoReserva = repoReserva;
        _repoPersona = repoPersona;
        _repoEventoDeportivo = repoEventoDeportivo;
        _autorizador = autorizador;
        _validador = validador;
    }

    public void Ejecutar(Reserva reserva, int IdUsuario)
    {
        string mensajeError;
        if (!_autorizador.PoseeElPermiso(IdUsuario, Permiso.ReservaModificacion))
        {
            throw new FalloAutorizacionException();
        }

        if (!_validador.ExistenPersonaYEvento(reserva.PersonaId, reserva.EventoDeportivoId, out mensajeError))
        {
            throw new EntidadNotFoundException(mensajeError);
        }

        if (!_validador.VerificarCupoDisponible(reserva.EventoDeportivoId, out mensajeError))
        {
            throw new DuplicadoException(mensajeError);
        }

        try
        {
            _repoReserva.ModificarReserva(reserva);
        }    
        catch
        {
            throw;
        }  
    }

}

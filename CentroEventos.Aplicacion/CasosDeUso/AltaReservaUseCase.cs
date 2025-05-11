using CentroEventos.Aplicaciones.Excepciones;
using CentroEventos.Aplicaciones.Validaciones;

public class AltaReservaUseCase
{
    private readonly IRepositorioReserva _repoReserva;
    private readonly IRepositorioPersona _repoPersona;
    private readonly IRepositorioEventoDeportivo _repoEventoDeportivo;
    private readonly IServicioAutorizacion _autorizador;

    public AltaReservaUseCase(IRepositorioReserva repoReserva, 
                              IRepositorioPersona repoPersona, 
                              IRepositorioEventoDeportivo repoEventoDeportivo,
                              IServicioAutorizacion autorizador)
    {
        _repoReserva = repoReserva;
        _repoPersona = repoPersona;
        _repoEventoDeportivo = repoEventoDeportivo;
        _autorizador = autorizador;
    }

    public void Ejecutar(Reserva reserva, int IdUsuario)
    {
        try
        {
            string error;
            if (!_autorizador.PoseeElPermiso(IdUsuario, Permiso.ReservaAlta))
            {
                throw new FalloAutorizacionException();
            }

            ValidarReserva validador = new ValidarReserva(_repoPersona, _repoEventoDeportivo, _repoReserva);
            if (!validador.ExistenPersonaYEvento(reserva.PersonaId, reserva.EventoDeportivoId, out error))
            {
                throw new EntidadNotFoundException();
            }

        }
        catch (Exception error)
        {
            Console.WriteLine(error); // o Console.WriteLine(error.Message); 
        }


        /*
        if (!validador.ExistenPersonaYEvento(reserva.PersonaId, reserva.EventoDeportivoId, out error))
        {
        throw new EntidadNotFoundException($"Error: {error}");
        }

        if (validador.YaReservado(reserva, out error))
        {
        throw new DuplicadoException($"Error: {error}");
        }

        if (!validador.VerificarCupoDisponible(reserva.EventoDeportivoId, out error))
        {
        throw new CupoExcedidoException($"Error: {error}");
        }

        try
        {
        _repoReserva.AltaReserva(reserva);
        }
        catch (System.Exception)
        {
        throw;
        }
        */
    }
}   

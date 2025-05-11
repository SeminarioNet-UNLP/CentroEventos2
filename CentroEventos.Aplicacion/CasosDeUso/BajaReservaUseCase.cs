using CentroEventos.Aplicaciones.Excepciones;
using CentroEventos.Aplicaciones.Validaciones;

public class BajaReservaUseCase
{
    private readonly IRepositorioReserva _repoReserva;
    private readonly IRepositorioPersona _repoPersona;
    private readonly IRepositorioEventoDeportivo _repoEventoDeportivo;

    public BajaReservaUseCase(IRepositorioReserva repoReserva, 
                              IRepositorioPersona repoPersona, 
                              IRepositorioEventoDeportivo repoEventoDeportivo)
    {
        _repoReserva = repoReserva;
        _repoPersona = repoPersona;
        _repoEventoDeportivo = repoEventoDeportivo;
    }

   public void Ejecutar(Reserva reserva)
{
    string error;
    ValidarReserva validador = new ValidarReserva(_repoPersona, _repoEventoDeportivo, _repoReserva);

    if (!validador.ExistenPersonaYEvento(reserva.PersonaId, reserva.EventoDeportivoId, out error))
    {
        throw new EntidadNotFoundException($"Error: {error}");
    }

    if (!validador.VerificarReservaExistente(reserva, out error))
    {
       throw new EntidadNotFoundException($"Error: {error}"); 
    } 

    if (!validador.VerificarCupoDisponible(reserva.EventoDeportivoId, out error))
    {
        throw new CupoExcedidoException($"Error: {error}");
    }

    try
    {
        _repoReserva.BajaReserva(reserva.Id);
    }
    catch (System.Exception)
    {
        throw;
    }
}
}   

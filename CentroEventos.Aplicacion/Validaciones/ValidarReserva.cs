using System.Diagnostics;
using CentroEventos.Aplicaciones.Excepciones;  // Este using es importante

namespace CentroEventos.Aplicaciones.Validaciones;
public class ValidarReserva
{
    private readonly IRepositorioPersona _repoPersona;
    private readonly IRepositorioEventoDeportivo _repoEventoDeportivo;
    private readonly IRepositorioReserva _repoReserva;
    public ValidarReserva (IRepositorioPersona repoPersona, IRepositorioEventoDeportivo repoEventoDeportivo, IRepositorioReserva repoReserva)
    {
        _repoPersona = repoPersona;
        _repoEventoDeportivo = repoEventoDeportivo;
        _repoReserva = repoReserva;

    }
    public bool ExistenPersonaYEvento(int IdPersona, int IdEvento, out string error)
    {
        error ="";
        List<Persona> personas = _repoPersona.ListadoPersona();
        List<EventoDeportivo> eventos = _repoEventoDeportivo.ListadoEventoDeportivo();
        bool condiP= false;
        bool condiE = false;
        for (int i = 0; i < personas.Count() && !condiP ; i++)
        {
            if(personas[i].Id == IdPersona)
            {   
                condiP = true;
            }
        }
        for (int i = 0; i < eventos.Count() && !condiE ; i++)
        {
            if(eventos[i].Id == IdEvento)
            {   
                condiE = true;
            }
        }
        if(condiP && condiE)
        {
            return true;
        }
        else
            throw new EntidadNotFoundException("Entidad encontrada");
    }
    public bool YaReservado(Reserva reserva, out string error)
{
    error = "";
    List<Reserva> reservas = _repoReserva.ListadoReserva();
    bool Condi = false;
    if(reservas != null)
    {
        int i = 0;
        for (; i < reservas.Count() && !Condi; i++)
        {
            Condi = (reservas[i].PersonaId == reserva.PersonaId) &&
                    (reservas[i].EventoDeportivoId == reserva.EventoDeportivoId);    
        }
        if (Condi)
        {   
            error = "No se puede reservar dos veces el mismo evento.";
            throw new OperacionInvalidaException(error);
        }
        else
        {
            return false;
        }
    }
    else
    {
        error = "No se encuentran reservas.";
        throw new Exception(error);
    }    
}

    public bool VerificarCupoDisponible(int eventoId, out string error)
{
    error = "";
    EventoDeportivo? eventoEncontrado = null;

    foreach (var evento in _repoEventoDeportivo.ListadoEventoDeportivo())
    {
        if (evento.Id == eventoId)
        {
            eventoEncontrado = evento;
            break;
        }
    }

    if (eventoEncontrado == null)
    {
        error = "El evento no existe.";
        return false;
    }

    int cantidadReservas = 0;
    foreach (var reserva in _repoReserva.ListadoReserva())
    {
        if (reserva.EventoDeportivoId == eventoId)
        {
            cantidadReservas++;
        }
    }

    if (cantidadReservas >= eventoEncontrado.CupoMaximo)
    {
        error = "No hay cupo disponible para este evento.";
        return false;
    }

    return true;
}
}
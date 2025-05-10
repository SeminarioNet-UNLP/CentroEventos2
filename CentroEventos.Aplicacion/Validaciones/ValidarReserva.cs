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
    public bool ExistenPersonaEvento(int IdPersona, int IdEvento)
    {
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
        return (condiP && condiE);
    }
    public bool YaReservado(EventoDeportivo evento, Persona persona)
    {
        List<Reserva> reservas = _repoReserva.ListadoReserva();
        if(reservas != null)
        {
            for (int i = 0; i < reservas.Count() ; i++)
            {
                if(reservas[i].PersonaId == persona.Id)
                {
                
                }
            }
        }    
        return true;
    }
}
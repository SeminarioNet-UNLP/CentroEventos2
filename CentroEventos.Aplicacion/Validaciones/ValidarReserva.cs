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
    public bool ExistenPersonaYEvento(int IdPersona, int IdEvento)
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
        if(condiP && condiE)
        {
            return true;
        }
        else
            throw new EntidadNotFoundException("Entidad encontrada");
    }
    public bool YaReservado(Reserva reserva)
    {
        List<Reserva> reservas = _repoReserva.ListadoReserva();
        bool Condi = false;
        if(reservas != null)
        {
            int i = 0;
            for ( ;i < reservas.Count() && !Condi ; i++)
            {
                Condi = (reservas[i].PersonaId == reserva.PersonaId) && 
                    (reservas[i].EventoDeportivoId == reserva.EventoDeportivoId);    
            }
            if(Condi)
            {   
               throw new OperacionInvalidaException("no se puede reservar dos veces el mismo eventos deportivo");
            }
            else
            {
                return false;
            }
        }
        else
        {
            throw new Exception("No se encuentran reservas");
        }    
        
    }
}
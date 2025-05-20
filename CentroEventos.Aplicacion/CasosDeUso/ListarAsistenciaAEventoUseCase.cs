using CentroEventos.Aplicaciones;
using CentroEventos.Aplicaciones.Excepciones;

public class ListarAsistenciaAEventoUseCase
{
    private readonly IRepositorioEventoDeportivo _repoEvento;
    private readonly IRepositorioReserva _repoReserva;
    private readonly IRepositorioPersona _repoPersona;


    public ListarAsistenciaAEventoUseCase(
        IRepositorioEventoDeportivo repoEvento,
        IRepositorioReserva repoReserva,
        IRepositorioPersona repoPersona)
    {
        _repoEvento = repoEvento;
        _repoReserva = repoReserva;
        _repoPersona = repoPersona;
    }
    
    public List<Persona> Ejecutar(int idEvento)
    {

        EventoDeportivo? eventoBuscado = null;
        List<EventoDeportivo> listaEventos = _repoEvento.ListadoEventoDeportivo();

        int i = 0;
        while (i < listaEventos.Count && eventoBuscado == null)
        {
            if (listaEventos[i].Id == idEvento)
            {
                eventoBuscado = listaEventos[i];
            }
            i++;
        }
        if (eventoBuscado == null)
        {
            throw new EntidadNotFoundException("No se encontró el evento con ese ID.");
        }

        if (eventoBuscado.FechaHoraInicio > DateTime.Now)
        {
            throw new OperacionInvalidaException("El evento todavía no ocurrió.");
        }

        List<Reserva> todasLasReservas = _repoReserva.ListadoReserva();
        List<Persona> todasPersonas = _repoPersona.ListadoPersona();
        List<Persona> personasAsistidas = new List<Persona>();

        if(todasLasReservas == null)
            throw  new Exception("No hay reservas realizadas");
        if (todasPersonas == null)
            throw new Exception("No hay personas");    

        foreach (Reserva reserva in todasLasReservas)
        {
            if (reserva.EventoDeportivoId == idEvento)
            {
                if (reserva.EstadoAsistencia == EstadosAsistencia.Presente)
                { 
                  foreach (Persona p in todasPersonas)
                  {
                      if (p.Id == reserva.PersonaId)
                      {
                          personasAsistidas.Add(p);
                      }
                  }
                }
              

            }
        }
        return personasAsistidas;
    }
    
}
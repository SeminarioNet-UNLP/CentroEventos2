using CentroEventos.Aplicaciones;
using CentroEventos.Aplicaciones.Excepciones;

public class ListarAsistenciaAEventoUseCase
{
    private readonly IRepositorioEventoDeportivo _repoEvento;
    private readonly IRepositorioReserva _repoReserva;

    public ListarAsistenciaAEventoUseCase(
        IRepositorioEventoDeportivo repoEvento,
        IRepositorioReserva repoReserva)
    {
        _repoEvento = repoEvento;
        _repoReserva = repoReserva;
    }

    /*public List<Reserva> Ejecutar(int idEvento)
    {
        EventoDeportivo? eventoBuscado = null;
        List<EventoDeportivo> listaEventos = _repoEvento.ListadoEventoDeportivo();

        foreach (EventoDeportivo evento in listaEventos)
        {
            if (evento.Id == idEvento)
            {
                eventoBuscado = evento;
                break;
            }
        }
    */

    //Esto fue lo se se me ocurrio para reemplazar el foreach con el "break" tan odiado
    
    public List<Reserva> Ejecutar(int idEvento)
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
        List<Reserva> reservasDelEvento = new List<Reserva>();

        foreach (Reserva reserva in todasLasReservas)
        {
            if (reserva.EventoDeportivoId == idEvento)
            {
                reservasDelEvento.Add(reserva);
            }
        }

        return reservasDelEvento;
    }
    
}
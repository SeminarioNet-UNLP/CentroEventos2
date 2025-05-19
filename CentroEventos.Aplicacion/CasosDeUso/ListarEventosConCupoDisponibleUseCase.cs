using CentroEventos.Aplicaciones;

public class ListarEventosConCupoDisponibleUseCase
{
    private readonly IRepositorioEventoDeportivo _repoEvento;
    private readonly IRepositorioReserva _repoReserva;

    public ListarEventosConCupoDisponibleUseCase(
        IRepositorioEventoDeportivo repoEvento,
        IRepositorioReserva repoReserva)
    {
        _repoEvento = repoEvento;
        _repoReserva = repoReserva;
    }

    public List<EventoDeportivo> Ejecutar()
    {
        List<EventoDeportivo> todosLosEventos = _repoEvento.ListadoEventoDeportivo();
        List<Reserva> todasLasReservas = _repoReserva.ListadoReserva();
        List<EventoDeportivo> eventosConCupo = new List<EventoDeportivo>();

        foreach (EventoDeportivo evento in todosLosEventos)
        {
            if (evento.FechaHoraInicio > DateTime.Now)
            {
                int cantidadReservas = 0;

                foreach (Reserva reserva in todasLasReservas)
                {
                    if (reserva.EventoDeportivoId == evento.Id)
                    {
                        cantidadReservas++;
                    }
                }

                if (cantidadReservas < evento.CupoMaximo)
                {
                    eventosConCupo.Add(evento);
                }
            }
        }

        return eventosConCupo;
    }
}
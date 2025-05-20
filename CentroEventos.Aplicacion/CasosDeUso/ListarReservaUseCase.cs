using CentroEventos.Aplicaciones;

public class ListarReservaUseCase
{
    private readonly IRepositorioReserva _repositorioReserva;

    public ListarReservaUseCase(IRepositorioReserva repositorioReserva)
    {
        _repositorioReserva = repositorioReserva;
    }

    public List<Reserva> Ejecutar() => _repositorioReserva.ListadoReserva();
   
}
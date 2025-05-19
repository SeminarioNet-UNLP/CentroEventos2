using CentroEventos.Aplicaciones;

public class ListarReservaUseCase
{
    private readonly IRepositorioReserva _repositorioReserva;

    public ListarReservaUseCase(IRepositorioReserva repositorioReserva)
    {
        _repositorioReserva = repositorioReserva;
    }

    public void Ejecutar()
    {
        List<Reserva> listaReserva = _repositorioReserva.ListadoReserva();

        foreach (Reserva res in listaReserva)
        {
            Console.WriteLine(res.ToString()+"\n");
        }

    }
}
using CentroEventos.Aplicaciones;

public class ListarEventosUseCase
{
    private readonly IRepositorioEventoDeportivo _repositorioEventoDeportivo;

    public ListarEventosUseCase(IRepositorioEventoDeportivo repositorioEventoDeportivo)
    {
        _repositorioEventoDeportivo = repositorioEventoDeportivo;
    }

    public void Ejecutar()
    {
        List<EventoDeportivo> listaEvento = _repositorioEventoDeportivo.ListadoEventoDeportivo();

        foreach (EventoDeportivo evento in listaEvento)
        {
            Console.WriteLine(evento.ToString() + "\n");
        }
    }
}
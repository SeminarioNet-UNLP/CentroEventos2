using CentroEventos.Aplicaciones;

public class ListarEventosUseCase
{
    private readonly IRepositorioEventoDeportivo _repositorioEventoDeportivo;

    public ListarEventosUseCase(IRepositorioEventoDeportivo repositorioEventoDeportivo)
    {
        _repositorioEventoDeportivo = repositorioEventoDeportivo;
    }

    public List<EventoDeportivo> Ejecutar() => _repositorioEventoDeportivo.ListadoEventoDeportivo();
    
}
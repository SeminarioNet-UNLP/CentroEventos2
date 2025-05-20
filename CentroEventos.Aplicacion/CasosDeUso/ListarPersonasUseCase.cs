using System.Collections;
using CentroEventos.Aplicaciones;

public class ListarPersonasUseCase
{
    private readonly IRepositorioPersona _repositorioPersona;

    public ListarPersonasUseCase(IRepositorioPersona repositorioPersona)
    {
        _repositorioPersona = repositorioPersona;
    }

    public List<Persona> Ejecutar() => _repositorioPersona.ListadoPersona();
    
}
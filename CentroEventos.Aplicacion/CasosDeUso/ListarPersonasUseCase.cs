using System.Collections;
using CentroEventos.Aplicaciones;

public class ListarPersonasUseCase
{
    private readonly IRepositorioPersona _repositorioPersona;

    public ListarPersonasUseCase(IRepositorioPersona repositorioPersona)
    {
        _repositorioPersona = repositorioPersona;
    }

    public void Ejecutar()
    {
        List<Persona> listaPersona = _repositorioPersona.ListadoPersona();

        foreach (Persona per in listaPersona)
        {
            Console.WriteLine(per.ToString() + "\n");
        }
    }
}
using CentroEventos.Aplicacion;

public class EstudianteAltaCDU : PersonaCDU
{
    public EstudianteAltaCDU(IPersonaRepositorio Repositorio) : base(Repositorio)
    {
    }
    public void Ejecutar(Estudiante e)
    {
        repositorio.AgregarPersona(e);
    }
    
}
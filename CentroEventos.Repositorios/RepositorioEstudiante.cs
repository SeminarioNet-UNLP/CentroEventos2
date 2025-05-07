using CentroEventos.Aplicacion;

public class RepositorioEstudiante : IPersonaRepositorio
{
    //private static string nombreTxt =  "PersistenciaPersona.txt";
    private static string nombreTxt = @"C:\Users\Usuario\proyectos\Sistema-de-Gestion-del-Centro-Deportivo-Universitario\CentroEventos.Repositorios\PersistenciaPersona.txt";

    public void AgregarPersona(Persona p )
    {
        try
        {
           using StreamWriter sw = new StreamWriter(nombreTxt, true);
           sw.WriteLine(p.ToString());
           
        }
        catch (System.Exception)
        {
            
            throw new Exception("No se creo");
        }
    }

    public void EliminarPersona(int id)
    {
        throw new NotImplementedException();
    }

    public List<Persona> ListarPersona()
    {
        throw new NotImplementedException();
    }

    public void ModificarPersona(Persona p)
    {
        throw new NotImplementedException();
    }

    public Persona ObtenerPersona(int id)
    {
        throw new NotImplementedException();
    }
}
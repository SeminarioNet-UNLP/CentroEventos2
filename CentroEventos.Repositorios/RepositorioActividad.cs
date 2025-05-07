using CentroEventos.Aplicacion;

public class RepositorioActividad : IActividadRepositorio
{
    private static string nombreTxt = @"C:\Users\Usuario\proyectos\Sistema-de-Gestion-del-Centro-Deportivo-Universitario\CentroEventos.Repositorios\PersistenciaActividad.txt";
  
    //Aca no van las validaciones
    public void CrearActividad(ActividadDeportiva actividad )
    {
        try
        {
           using StreamWriter sw = new StreamWriter(nombreTxt, true);
           sw.WriteLine(actividad.ToString());
           
        }
        catch (System.Exception)
        {
         
            throw new Exception("Validation Exception: No se pudo crear la actividad, deporte ingresado no existe.");
        }
    } 

    public void EliminarActividad(int id) //como en fod, hago while not eof (busco el id). Si encontre y es =/= de null
    {
        
    }

    public List<ActividadDeportiva> listarTodos()
    {
        throw new NotImplementedException();
    }

    public void ModificarActividad(ActividadDeportiva actividad)
    {
        throw new NotImplementedException();
    }

  
}
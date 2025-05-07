using CentroEventos.Aplicacion;

public class ActividadAltaCDU
{
    public IActividadRepositorio Repositorio {get;set;}
    public ActividadAltaCDU(IActividadRepositorio repositorio) 
    {
        Repositorio=repositorio;
    }

    //Idea: no seria mejor hacer un solo caso de uso en actividad y ponerle todos los metodos? altas,bajas,modificaciones y listas
    // sino tendriamos 4 por cada uno: 16 en total.
    public void Ejecutar(ActividadDeportiva actividad)
    {
        try 
        { 
           ValidarActividad.CampoVacio(actividad.deporte.ToString());
           ValidarActividad.VerCupo(actividad.cupoMax);
           //aca iria el validaractividad de la fecha, pero no pude resolverlo :(.
           //aca iria el tipoactividad y responsable validos que no sabemos como se hace.
           Repositorio.CrearActividad(actividad);
        }
        catch (Exception e) 
        {
           throw new Exception ($"Se produjo un error {e.Message}");
        }
              
    }


    
}
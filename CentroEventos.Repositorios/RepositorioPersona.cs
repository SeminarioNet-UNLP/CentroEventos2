
public class RepositorioPersona : IRepositorioPersona
{
   

private readonly string rutaIDs = Path.Combine("C:", "Users", "Usuario", "proyectos", 
    "Sistema-de-Gestion-del-Centro-Deportivo-Universitario", "CentroEventos.Repositorios", 
    "ArchivosPersistencia", "IdPersona.txt");

private readonly string archivoPersonas = Path.Combine("C:", "Users", "Usuario", "proyectos", 
    "Sistema-de-Gestion-del-Centro-Deportivo-Universitario", "CentroEventos.Repositorios", 
    "ArchivosPersistencia", "PersonasPersistencia.txt");


    public void AltaPersona(Persona persona)
    {
       int ultimoId= BusquedaId.BuscarUltimoId(rutaIDs);
       if(ultimoId >= 0)
       {
           persona.Id = ultimoId+1;
           try
           {   
               using (StreamWriter sw = new StreamWriter(archivoPersonas, true))
               {
                   sw.WriteLine(persona.ToString());
               }
           }
           catch (Exception e)
           {
               
               throw new Exception($"No se pudo cargar el archivo: {e.Message}");
           } 
           BusquedaId.ActualizarArchivoId(rutaIDs,persona.Id);
       }
    }

    public void BajaPersona(int id)
    {
        throw new NotImplementedException();
    }

    public List<Persona> ListadoPersona()
    {
        throw new NotImplementedException();
    }

    public void ModificarPersona(Persona persona)
    {
        throw new NotImplementedException();
    }
}
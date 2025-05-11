
using CentroEventos.Aplicaciones.Excepciones;
using CentroEventos.Aplicaciones.Validaciones;
using Microsoft.Win32.SafeHandles;

public class RepositorioPersona : IRepositorioPersona
{
    private const int CantPropsPersona = 6;
    private readonly string rutaIDs = Path.Combine("C:", "Users", "Usuario", "proyectos", 
    "Sistema-de-Gestion-del-Centro-Deportivo-Universitario", "CentroEventos.Repositorios", 
    "ArchivosPersistencia", "IdPersona.txt");

    private readonly string archivoPersonas = Path.Combine("C:", "Users", "Usuario", "proyectos", 
    "Sistema-de-Gestion-del-Centro-Deportivo-Universitario", "CentroEventos.Repositorios", 
    "ArchivosPersistencia", "PersonasPersistencia.txt");


    public void AltaPersona(Persona persona)
    {
       string mensajeError;
       int ultimoId= BusquedaId.BuscarUltimoId(rutaIDs,out mensajeError);
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
       else
       {
           throw new Exception($"Error: {mensajeError}");
       }
    }

    public void BajaPersona(int id)
    {
        throw new NotImplementedException();
    }

    public List<Persona> ListadoPersona()
    {
       
        List<Persona> personas = new List<Persona>();
        try
        {
            using (StreamReader sr = new StreamReader(archivoPersonas))
            {
                string? lineaP;
                while((lineaP = sr.ReadLine()) != null)
                {
                    string[]campos = lineaP.Split(" ");
                    if(campos.Length == CantPropsPersona)
                    {
                        Persona per = new Persona(
                            campos[1], 
                            campos[2],
                            campos[3],
                            campos[4],
                            campos[5]
                        );
                        per.Id = int.Parse(campos[0]);
                        personas.Add(per);
                    }
                }
            }
        }
        catch (Exception e)
        {
            throw new Exception($"No se pudo acceder al archivo. {e.Message}");
        }
        return personas;
    }

    public void ModificarPersona(Persona persona)
    {
        throw new NotImplementedException();
    }
}
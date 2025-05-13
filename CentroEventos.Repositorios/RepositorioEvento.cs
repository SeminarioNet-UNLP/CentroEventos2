
using CentroEventos.Aplicaciones.Excepciones;

public class RepositorioEventoDeportivo : IRepositorioEventoDeportivo
{
     private const int CantPropsPersona = 6;
    private readonly string rutaIDs = Path.Combine("C:", "Users", "Usuario", "proyectos", 
    "Sistema-de-Gestion-del-Centro-Deportivo-Universitario", "CentroEventos.Repositorios", 
    "ArchivosPersistencia", "IdPersona.txt");

    private readonly string archivoEventos = Path.Combine("C:", "Users", "Usuario", "proyectos", 
    "Sistema-de-Gestion-del-Centro-Deportivo-Universitario", "CentroEventos.Repositorios", 
    "ArchivosPersistencia", "eventosPersistencia.txt");
    public void AltaEventoDeportivo(EventoDeportivo evento)
    {
       string mensajeError;
       int ultimoId= IdManager.BuscarUltimoId(rutaIDs,out mensajeError);
       if(ultimoId >= 0)
       {
           evento.Id = ultimoId+1;
           try
           {   
               using (StreamWriter sw = new StreamWriter(archivoEventos, true))
               {
                   sw.WriteLine(evento.ToString());
               }
               IdManager.ActualizarArchivoId(rutaIDs,evento.Id);
           }
           catch (Exception e)
           {
               throw new Exception(e.Message);
           }  
       }
       else
       {
           throw new Exception($"Error: {mensajeError}");
       }
    }

    public void BajaEventoDeportivo(int id)
    {
        bool encontrePersona= false;
        List<EventoDeportivo> eventos = ListadoEventoDeportivo();
        for (int i = 0; i < eventos.Count() &&  encontrePersona; i++)
        {
            if(eventos[i].Id == id) 
            {
                eventos.RemoveAt(i);
             encontrePersona = true;
            }  
        }
        if (encontrePersona)
        {
            using(StreamWriter sw = new StreamWriter(archivoEventos))
            {
                foreach (EventoDeportivo p in eventos)
                {
                    sw.WriteLine(p.ToString());
                }
            }   
        }
        else
        {
            throw new EntidadNotFoundException("No se encontro el id correspondiente");
        }
    }

    public List<EventoDeportivo> ListadoEventoDeportivo()
    {
         List<EventoDeportivo> eventos = new List<EventoDeportivo>();
        try
        {
            using (StreamReader sr = new StreamReader(archivoEventos))
            {
                string? lineaP;
                while((lineaP = sr.ReadLine()) != null)
                {
                    string[]campos = lineaP.Split(" ");
                    if(campos.Length == CantPropsPersona)
                    {
                        EventoDeportivo even = new EventoDeportivo(
                            campos[1], 
                            campos[2],
                            DateTime.Parse(campos[3]),
                            double.Parse(campos[4]),
                            int.Parse(campos[5]),
                            int.Parse(campos[6])
                        );
                        even.Id = int.Parse(campos[0]);
                        eventos.Add(even);
                    }
                }
            }
        }
        catch (Exception e)
        {
            throw new Exception($"No se pudo acceder al archivo. {e.Message}");
        }
        return eventos;
    }

    public void ModificarEventoDeportivo(EventoDeportivo evento)
    {
        List<EventoDeportivo> eventos = ListadoEventoDeportivo();
        bool encontrePersona = false;
        for (int i = 0; i < eventos.Count() &&  encontrePersona; i++)
        {
            if(eventos[i].Id == evento.Id)
            {
                eventos[i] = evento;
                encontrePersona= true;
            }
            
        }
        if(!encontrePersona)
        {    
            throw new EntidadNotFoundException("No se encontro el id correspondiente");
        }
    }
}
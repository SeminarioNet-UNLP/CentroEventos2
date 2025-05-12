using CentroEventos.Aplicaciones.Excepciones;

public class RepositorioReserva : IRepositorioReserva
{
   

private readonly string rutaIDs = Path.Combine("C:", "Users", "Usuario", "proyectos", 
    "Sistema-de-Gestion-del-Centro-Deportivo-Universitario", "CentroEventos.Repositorios", 
    "ArchivosPersistencia", "IdReservaa.txt");

private readonly string archivoReservas = Path.Combine("C:", "Users", "Usuario", "proyectos", 
    "Sistema-de-Gestion-del-Centro-Deportivo-Universitario", "CentroEventos.Repositorios", 
    "ArchivosPersistencia", "ReservasPersistencia.txt");


    public void AltaReserva(Reserva reserva)
    {
       string mensajeError = "";
       int ultimoId= BusquedaId.BuscarUltimoId(rutaIDs, out mensajeError);
       if(ultimoId >= 0)
       {
           reserva.Id = ultimoId+1;
           try
           {   
               using (StreamWriter sw = new StreamWriter(archivoReservas, true))
               {
                   sw.WriteLine(reserva.ToString());
               }
           }
           catch (Exception e)
           {
               
               throw new Exception(e.Message);
           } 
           BusquedaId.ActualizarArchivoId(rutaIDs,reserva.Id);
       }
    }

    // Ver si las bajas deberian ser un bool
    public void BajaReserva(int id)
    {
        if (id<0)
        {
             throw new ValidacionException ("No puede ser negativo el ID.");
        }
        try
    {
        var archivo = File.ReadAllLines(archivoReservas);
        var nuevoarchivo = new List<string>();
        bool encontre = false;
        foreach (var linea in archivo)
        {
               var partes = linea.Split(' ');
                if (int.Parse(partes[0])== id)
                {
                    encontre = true; 
                    continue;// Si encontre ID, no lo agrego al nuevo archivo
                }
       
            nuevoarchivo.Add(linea); // se agrega al nuevo archivo si no es la que quiero eliminar
        } 
        if (!encontre)
            throw new Exception("No se encontro reserva con el ID.");
        File.WriteAllLines(archivoReservas, nuevoarchivo);// sobreescribo el archivo con las lineas restantes
    }
    catch (Exception e)
    {
        throw new Exception($"Error al eliminar la reserva: {e.Message}");
    }
    }



    public List<Reserva> ListadoReserva()
    {    
        List<Reserva> listaReservas = new List<Reserva>();
        try
        {
            using (StreamReader sr = new StreamReader(archivoReservas))
            {
                string? lineaP;
                while((lineaP = sr.ReadLine()) != null)
                {
                    string[]campos = lineaP.Split(" ");
                    if(campos.Length == 5)
                    {
                        Reserva reserva = new Reserva(
                            int.Parse(campos[1]), 
                            int.Parse(campos[2]),
                            DateTime.Parse(campos[3]),
                            Enum.Parse<EstadosAsistencia>(campos[4])
                        );
                        reserva.Id = int.Parse(campos[0]);
                        listaReservas.Add(reserva);
                    }
                }
            }
        }
        catch (Exception e)
        {
            throw new Exception($"No se pudo acceder al archivo. {e.Message}");
        }
     return listaReservas;
    }



    public void ModificarReserva(Reserva reserva)
    {
        List<Reserva> listaReservas = ListadoReserva();
        bool cambie = false;
        for (int i = 0; i < listaReservas.Count(); i++)
        {
            if(listaReservas[i].Id == reserva.Id)
            {
                listaReservas[i] = reserva;
                cambie= true;
                break;
            }           
        }
        if(cambie==false)
        {    
            throw new EntidadNotFoundException("ID no encontrado. No se puede modificar la reserva.");
        }
    }
}
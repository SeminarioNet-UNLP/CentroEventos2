
namespace CentroEventos.Repositorios;

public class RepositorioEventoDeportivo : IRepositorioEventoDeportivo
{
    private readonly string rutaIDs = Path.Combine("C:", "Users", "Usuario", "proyectos", 
    "Sistema-de-Gestion-del-Centro-Deportivo-Universitario", "CentroEventos.Repositorios", 
    "ArchivosPersistencia", "IdEventosDeportivos.txt");

    private readonly string archivoEventosDeportivos = Path.Combine("C:", "Users", "Usuario", "proyectos", 
    "Sistema-de-Gestion-del-Centro-Deportivo-Universitario", "CentroEventos.Repositorios", 
    "ArchivosPersistencia", "EventosDeportivosPersistencia.txt");

    public void AltaEventoDeportivo(EventoDeportivo evento)
    {
        int ultimoId = BusquedaId.BuscarUltimoId(rutaIDs);
        if (ultimoId >= 0)
        {
            evento.Id = ultimoId + 1;
            try
            {
                using StreamWriter sw = new StreamWriter(archivoEventosDeportivos, true);
                sw.WriteLine(evento.ToString());
            }
            catch (Exception e)
            {
                throw new Exception($"No se pudo cargar el archivo: {e.Message}");
            }
            BusquedaId.ActualizarArchivoId(rutaIDs, evento.Id);
        }
    }

    public void BajaEventoDeportivo(int id)
    {
        throw new NotImplementedException();
    }

    public List<EventoDeportivo> ListadoEventoDeportivo()
    {
        throw new NotImplementedException();
    }

    public void ModificarEventoDeportivo(EventoDeportivo evento)
    {
        if (evento.Id > 0)
        {
            try
            {
                using StreamWriter sw = new StreamWriter(archivoEventosDeportivos, true);
                sw.WriteLine(evento.ToString());
            }
            catch (Exception e)
            {
                throw new Exception($"No se pudo cargar el archivo: {e.Message}");
            }
            BusquedaId.ActualizarArchivoId(rutaIDs, evento.Id);
        }
    }
    
}
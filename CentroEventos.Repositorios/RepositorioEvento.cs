using CentroEventos.Aplicaciones.Excepciones;

public class RepositorioEventoDeportivo : IRepositorioEventoDeportivo
{
    public void AltaEventoDeportivo(EventoDeportivo eventoDeportivo)
    {
        using (var context = new CentroEventosContext())
        {
            context.Add(eventoDeportivo);
            context.SaveChanges();
        }
    }

    public void BajaEventoDeportivo(int id)
    {
        using (var context = new CentroEventosContext())
        {
            var query = context.EventoDeportivos.SingleOrDefault(eD => eD.Id == id);
            if (query != null)
            {
                context.Remove(query);
                context.SaveChanges();
            }
            else
            {
                throw new EntidadNotFoundException($"Error: El evento deportivo a eliminar no existe.");
            }
        }
    }

    public List<EventoDeportivo> ListadoEventoDeportivo()
    {
        using (var context = new CentroEventosContext())
        {
            return context.EventoDeportivos.ToList();
        }
    }

    public void ModificarEventoDeportivo(EventoDeportivo eventoDeportivo)
    {
        using (var context = new CentroEventosContext())
        {
            var query = context.EventoDeportivos.SingleOrDefault(r => r.Id == eventoDeportivo.Id);
            if (query != null)
            {
                query = eventoDeportivo;
                context.SaveChanges();
            }
            else
            {
                throw new EntidadNotFoundException($"Error: El evento deportivo a modificar no existe.");
            }
        }
    }

}
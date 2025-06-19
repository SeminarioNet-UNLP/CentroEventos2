using CentroEventos.Aplicaciones.Excepciones;

public class RepositorioReserva : IRepositorioReserva
{
    public void AltaReserva(Reserva reserva)
    {
        using (var context = new CentroEventosContext())
        {
            context.Add(reserva);
            context.SaveChanges();
        }
    }

    public void BajaReserva(int id)
    {
        using (var context = new CentroEventosContext())
        {
            var query = context.Reservas.SingleOrDefault(r => r.Id == id);
            if (query != null)
            {
                context.Remove(query);
                context.SaveChanges();
            }
            else
            {
                throw new EntidadNotFoundException($"Error: La reserva a eliminar no existe.");
            }
        }
    }

    public List<Reserva> ListadoReserva()
    {
        using (var context = new CentroEventosContext())
        {
            return context.Reservas.ToList();
        }
    }

    public void ModificarReserva(Reserva reserva)
    {
        using (var context = new CentroEventosContext())
        {
            var query = context.Reservas.SingleOrDefault(r => r.Id == reserva.Id);
            if (query != null)
            {
                query.PersonaId = reserva.PersonaId;
                query.EventoDeportivoId = reserva.EventoDeportivoId;
                query.FechaAltaReserva = reserva.FechaAltaReserva;
                query.EstadoAsistencia = reserva.EstadoAsistencia;

                context.SaveChanges();
            }
            else
            {
                throw new EntidadNotFoundException($"Error: La reserva a modificar no existe.");
            }
        }
    }

}
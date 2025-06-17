using Microsoft.EntityFrameworkCore;

public class CentroEventosContext : DbContext
{
    public DbSet<Persona> Personas { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<EventoDeportivo> EventoDeportivos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder
    optionsBuilder)
    {
            optionsBuilder.UseSqlite("data source=CentroEventos");
    }
}
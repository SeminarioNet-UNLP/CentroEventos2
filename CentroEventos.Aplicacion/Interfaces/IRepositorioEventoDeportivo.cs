public interface IRepositorioEventoDeportivo
{
    public void AltaEventoDeportivo(EventoDeportivo evento);
    public void ModificarEventoDeportivo(EventoDeportivo evento);
    public void BajaEventoDeportivo(int id);
    public List<EventoDeportivo> ListadoEventoDeportivo();
}
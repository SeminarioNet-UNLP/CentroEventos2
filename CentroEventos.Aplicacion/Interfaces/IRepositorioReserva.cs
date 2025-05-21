public interface IRepositorioReserva
{
    public void AltaReserva(Reserva reserva);
    public void ModificarReserva(Reserva reserva);
    public void BajaReserva(int id);
    public List<Reserva> ListadoReserva();
}
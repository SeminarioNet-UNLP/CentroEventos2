public interface IRepositorioUsuario
{
    
    public void AltaUsuario(Usuario reserva);
    public void ModificarUsuario(Usuario reserva);
    public void BajaUsuario(int id);
    public List<Usuario> ListadoUsuario();
}
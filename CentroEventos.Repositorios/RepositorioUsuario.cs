namespace CentroEventos.Aplicacion.Repositorios;

public interface IRepositorioUsuario
{
    void AltaUsuario(Usuario usuario);
    void ModificarUsuario(Usuario usuario);
    void BajaUsuario(int id);
    List<Usuario> ListadoUsuarios();
    Usuario? ObtenerUsuarioPorId(int id);
    Usuario? ObtenerUsuarioPorCorreo(string correo);
    
 }
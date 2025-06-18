namespace CentroEventos.Aplicacion.Repositorios;

public interface IRepositorioUsuario
{
    public void AltaUsuario(Usuario usuario);
    public void ModificarUsuario(Usuario usuario);
    public void BajaUsuario(int id);
    public List<Usuario> ListadoUsuarios();
    public Usuario? ObtenerUsuarioPorId(int id);
    public Usuario? ObtenerUsuarioPorCorreo(string correo);
    public bool AsignarPermisos(Usuario usuario, Permiso permiso);
    
 }
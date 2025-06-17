public interface IServicioAutorizacion
{
    public bool LogIn(Usuario usuario);
    //public bool Registrar(Usuario usuario); seria el alta de un usuario normal
    public bool LogOut();
    public Usuario? ObtenerUsuarioActivo(); // puede ser null por si no esta logeado nadie
    public bool PoseeElPermiso(Usuario usuario, Permiso permiso);
 }
public class ServicioAutorizacion : IServicioAutorizacion
{   
   
    public Usuario? usuarioActivo { get; set; }
    public bool LogIn(Usuario usuario)
    {
        usuarioActivo = usuario;
        return true;
    }    
       

    public bool LogOut()
    {
        usuarioActivo = null;
        return true;
    }

    public Usuario? ObtenerUsuarioActivo()
    {
        return usuarioActivo;
    }

    public bool PoseeElPermiso(Usuario usuario, Permiso permiso)
    {
        if (usuario != null)
        {
            return usuario.Permisos.Any(u => u == permiso);
        }
        else
        {
            return false;
        }
    }

}
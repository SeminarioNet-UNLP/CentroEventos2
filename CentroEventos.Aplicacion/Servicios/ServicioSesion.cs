public class ServicioSesion : ISesion
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
}
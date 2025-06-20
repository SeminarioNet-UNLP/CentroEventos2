public interface ISesion
{ 
    public bool LogIn(Usuario usuario);
    
    public bool LogOut();
    public Usuario? ObtenerUsuarioActivo(); 
}
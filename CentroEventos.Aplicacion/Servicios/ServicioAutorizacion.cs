public class ServicioAutorizacion : IServicioAutorizacion
{   
   
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
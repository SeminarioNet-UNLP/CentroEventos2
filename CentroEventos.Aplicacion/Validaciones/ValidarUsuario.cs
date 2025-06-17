namespace CentroEventos.Aplicaciones.Validaciones;
public class ValidarUsuario
{
    public bool CamposVacios (Usuario? usuario, out string mensajeError)
    {
        mensajeError = "";
        if (usuario == null) // Este if es para evitar el warning en las comparaciones posteriores
        {
            mensajeError = "Error. El usuario no puede ser nulo.";
            return false;
        }
        if (string.IsNullOrWhiteSpace(usuario.Nombre))
            mensajeError = "Error. El nombre no puede estar vacio.";         
        if (string.IsNullOrWhiteSpace(usuario.Apellido))
           mensajeError = "Error. El apellido no puede estar vacia.";
        if (string.IsNullOrWhiteSpace(usuario.CorreoElectronico))
            mensajeError = "Error. El email no puede estar vacio";     
        if (string.IsNullOrWhiteSpace(usuario.Clave)) // Esto está bien? Si no podemos ver su clave
            mensajeError = "Error. La clave no puede estar vacia.";
        return mensajeError == "";
    }
    
}
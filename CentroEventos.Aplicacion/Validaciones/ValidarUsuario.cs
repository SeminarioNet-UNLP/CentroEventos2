using CentroEventos.Aplicacion.Repositorios;

namespace CentroEventos.Aplicaciones.Validaciones;

public class ValidarUsuario
{
    private readonly IRepositorioUsuario _repUsuario;
    public ValidarUsuario(IRepositorioUsuario repoUsuario)
    {
        _repUsuario = repoUsuario;
    }

    public bool CamposVacios(Usuario? usuario, out string mensajeError)
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

    public bool ExisteUsuario(Usuario usuario, out string mensajeError)
    {
        mensajeError = "";
        var usuarios = _repUsuario.ListadoUsuarios();
        if (usuarios != null)
        {
            if (usuario.Clave != null)
            {
                usuarios.Any(u => u.CorreoElectronico == usuario.CorreoElectronico && u.Clave == HashingUtil.ConvertirCadena(usuario.Clave));
            }
            else
            {
                mensajeError = "Clave en blanco";
            }
        }
        else
        {
            mensajeError = "No existe el usuario";
        }
        return mensajeError == "";
    }
    
}
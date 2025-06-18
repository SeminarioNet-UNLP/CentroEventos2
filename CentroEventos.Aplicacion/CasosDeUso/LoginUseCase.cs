using CentroEventos.Aplicacion.Repositorios;
using CentroEventos.Aplicaciones.Excepciones;
using CentroEventos.Aplicaciones.Validaciones;

public class LoginUseCase
{
    private readonly IServicioAutorizacion _autorizador;
    private readonly IRepositorioUsuario _repoUsuario;
    private readonly ValidarUsuario _validador;
    public LoginUseCase(IServicioAutorizacion autorizador, IRepositorioUsuario repoUsuario, ValidarUsuario validador)
    {
        _autorizador = autorizador;
        _validador = validador;
        _repoUsuario = repoUsuario;
    }
    public void Ejecutar(Usuario usuario)
    {
        string mensajeError = "";
        if (!_validador.ExisteUsuario(usuario, out mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }
        if (usuario.CorreoElectronico == null || usuario.Clave == null)
        {
            throw new ValidacionException("Hay campos vacios");
        }
        var usuarioBuscar = _repoUsuario.ObtenerUsuarioPorCorreo(usuario.CorreoElectronico);
        if (usuarioBuscar == null  )
        {
            throw new EntidadNotFoundException("No se encuentra el usuario");
        }
        if (usuarioBuscar.Clave == usuario.Clave)
        { 
            _autorizador.LogIn(usuarioBuscar);
        }
        else
        {
            throw new OperacionInvalidaException("Contraseña invalida");
        }
            
        
    }
}
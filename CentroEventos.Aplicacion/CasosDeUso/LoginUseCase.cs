using CentroEventos.Aplicaciones.Excepciones;
using CentroEventos.Aplicaciones.Validaciones;

public class LoginUseCase
{
    private readonly IServicioAutorizacion _autorizador;
    private readonly ValidarUsuario _validador;
    public LoginUseCase(IServicioAutorizacion autorizador, ValidarUsuario validador)
    {
        _autorizador = autorizador;
        _validador = validador;
    }
    public void Ejecutar(Usuario usuario)
    {
        string mensajeError = "";
        if (!_validador.ExisteUsuario(usuario, out mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }
        _autorizador.LogIn(usuario);
    }
}
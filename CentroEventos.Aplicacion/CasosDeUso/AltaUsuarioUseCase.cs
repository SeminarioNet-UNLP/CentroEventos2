using CentroEventos.Aplicacion.Repositorios;
using CentroEventos.Aplicaciones.Excepciones;
using CentroEventos.Aplicaciones.Validaciones;

public class AltaUsuarioUseCase
{
    private readonly IRepositorioUsuario _repoUsuario;
    private readonly IServicioAutorizacion _autorizador;
    private readonly ValidarUsuario _validador;

    public AltaUsuarioUseCase(IRepositorioUsuario repoUsuario,
                             IServicioAutorizacion autorizador,
                             ValidarUsuario validador)
    {
        _repoUsuario = repoUsuario;
        _autorizador = autorizador;
        _validador = validador;
    }

    public void Ejecutar(Usuario usuario, Usuario usuarioRespo)
    {
        string mensajeError;

        if (!_autorizador.PoseeElPermiso(usuarioRespo, Permiso.Administrador))
        {
            throw new FalloAutorizacionException("No tiene permiso para crear usuarios.");
        }

        if (!_validador.CamposVacios(usuario, out mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }

        try
        {
            _repoUsuario.AltaUsuario(usuario);
        }
        catch
        {
            throw;
        }

    }
}



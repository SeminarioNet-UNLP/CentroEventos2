using CentroEventos.Aplicaciones.Excepciones;
using CentroEventos.Aplicaciones.Validaciones;

public class ModificarUsuarioUseCase
{
    private readonly IRepositorioUsuario _repoUsuario;
    private readonly IServicioAutorizacion _autorizador;
    private readonly ValidarUsuario _validador;

    public ModificarUsuarioUseCase(IRepositorioUsuario repoUsuario,
                             IServicioAutorizacion autorizador,
                             ValidarUsuario validador)
    {
        _repoUsuario = repoUsuario;
        _autorizador = autorizador;
        _validador = validador;
    }

    public void Ejecutar(Usuario usuario, int idQueSolicita)
    {
        string mensajeError;

        if (!_autorizador.PoseeElPermiso(idQueSolicita, Permiso.UsuarioAlta))
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


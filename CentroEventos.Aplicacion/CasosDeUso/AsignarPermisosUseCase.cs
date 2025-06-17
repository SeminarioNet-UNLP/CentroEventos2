using CentroEventos.Aplicacion.Repositorios;
using CentroEventos.Aplicaciones.Excepciones;

public class AsignarPermisosUseCase
{ 
    private readonly IServicioAutorizacion _autorizador;
    private readonly IRepositorioUsuario _repoUsuario;
    public AsignarPermisosUseCase(IServicioAutorizacion autorizador, IRepositorioUsuario repoUsuario)
    {
        _autorizador = autorizador;
        _repoUsuario = repoUsuario;
    }
    public void Ejecutar(Usuario aModificar, Permiso AOtorgar)
    {
        Usuario? usuarioActivo = _autorizador.ObtenerUsuarioActivo();
        if (usuarioActivo != null && _autorizador.PoseeElPermiso(usuarioActivo, Permiso.Administrador))
        {
            if (!_repoUsuario.AsignarPermisos(aModificar, AOtorgar))
            {
                throw new OperacionInvalidaException("no se pudo modificar los permisos");
            }
        }
        else
        {
            throw new FalloAutorizacionException("No tienes permiso para modificar");
        }
    }
}
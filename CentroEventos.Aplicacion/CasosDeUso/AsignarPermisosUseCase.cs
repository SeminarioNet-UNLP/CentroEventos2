
using CentroEventos.Aplicacion.Repositorios;
using CentroEventos.Aplicaciones.Excepciones;

public class AsignarPermisosUseCase
{ 
    private readonly ISesion _sesion;
    private readonly IServicioAutorizacion _autorizador;
    private readonly IRepositorioUsuario _repoUsuario;
    public AsignarPermisosUseCase(IServicioAutorizacion autorizador, ISesion sesion, IRepositorioUsuario repoUsuario)
    {
        _sesion = sesion;
        _autorizador = autorizador;
        _repoUsuario = repoUsuario;
    }
    public void Ejecutar(Usuario aModificar, Permiso AOtorgar)
    {
        Usuario? usuarioActivo = _sesion.ObtenerUsuarioActivo();
        if (usuarioActivo != null && _autorizador.PoseeElPermiso(usuarioActivo, Permiso.Administrador))
        {
            if (aModificar.Permisos.Contains(AOtorgar))
            {
               throw new OperacionInvalidaException("Ya tiene ese permiso");
            }
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
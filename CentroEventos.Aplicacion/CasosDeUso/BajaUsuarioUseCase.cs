using CentroEventos.Aplicaciones.Excepciones;
using CentroEventos.Aplicaciones.Validaciones;
using System.Collections.Generic;

public class BajaUsuarioUseCase
{
    private readonly IRepositorioUsuario _repoUsuario;
    private readonly IServicioAutorizacion _autorizador;

    public BajaUsuarioUseCase(IRepositorioUsuario repoUsuario,
                             IServicioAutorizacion autorizador)
    {
        _repoUsuario = repoUsuario;
        _autorizador = autorizador;
    }

    public void Ejecutar(int idAEliminar, Usuario usuario)
    {
        List<Usuario> usuarios = _repoUsuario.ListadoUsuario();

        if (!_autorizador.PoseeElPermiso(usuario, Permiso.Administrador))
        {
            throw new FalloAutorizacionException();
        }

        bool existe = false;
        if (usuarios != null)
        {
            for (int i = 0; i < usuarios.Count; i++)
            {
                if (usuarios[i].Id == idAEliminar)
                {
                    existe = true;
                }
            }
        }

        if (!existe)
        {
            throw new OperacionInvalidaException("El usuario a eliminar no existe.");
        }

        try
        {
            _repoUsuario.BajaUsuario(idAEliminar);
        }
        catch
        {
            throw;
        }
    }
}

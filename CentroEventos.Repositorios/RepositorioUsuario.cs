using CentroEventos.Aplicacion.Repositorios;
using CentroEventos.Aplicaciones.Excepciones;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class RepositorioUsuario : IRepositorioUsuario
{
    private  readonly  CentroEventosContext _context;
    public RepositorioUsuario(CentroEventosContext context)
    {
        _context = context;
    }
    public void AltaUsuario(Usuario usuario)
    {
        var usuarios = _context.Usuarios.ToList();
        if (usuario != null )
        {
            if (usuarios.Count() ==0)
            {
                usuario.Permisos.Add(Permiso.Administrador);
            } 
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }
    }

    public bool AsignarPermisos(Usuario usuario, Permiso permiso)
    {
        if (usuario != null)
        {
            var buscarUs = _context.Usuarios.FirstOrDefault(u => u.Id == usuario.Id);
            if (buscarUs != null)
            {
                buscarUs.Permisos.Add(permiso);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;            
        }
    }

    public void BajaUsuario(int id)
    {
        var usuarioEliminar = _context.Usuarios.FirstOrDefault(u => u.Id == id);
        if (usuarioEliminar != null)
        {
            _context.Usuarios.Remove(usuarioEliminar);
            _context.SaveChanges();
        }
        else
        {
            throw new EntidadNotFoundException("No se encontro el id correspondiente");
        }
    }

    public List<Usuario> ListadoUsuarios()
    {
        return _context.Usuarios.ToList();
    }

    public void ModificarUsuario(Usuario usuario)
    {
        var usMod = _context.Usuarios.SingleOrDefault(u => u.Id == usuario.Id);
            if (usMod != null)
            {
               usMod.Nombre = usuario.Nombre;
               usMod.Apellido = usuario.Apellido;
               usMod.CorreoElectronico = usuario.CorreoElectronico;
               usMod.Permisos = usuario.Permisos;
               _context.SaveChanges();
            }
            else
            {
                throw new EntidadNotFoundException("No se encontro el id correspondiente");
            }
    }

    public Usuario? ObtenerUsuarioPorCorreo(string correo)
    {
        return _context.Usuarios.FirstOrDefault(u => u.CorreoElectronico == correo);
    }

    public Usuario? ObtenerUsuarioPorId(int id)
    {
        return _context.Usuarios.FirstOrDefault(u => u.Id == id);
    }
}
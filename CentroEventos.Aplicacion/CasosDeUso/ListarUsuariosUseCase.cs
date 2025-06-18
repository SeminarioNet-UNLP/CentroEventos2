using System.Collections;
using CentroEventos.Aplicaciones;


public class ListarUsuariosUseCase
{
    private readonly IRepositorioUsuario _repositorioUsuario;

    public ListarUsuariosUseCase(IRepositorioUsuario repositorioUsuario)
    {
        _repositorioUsuario = repositorioUsuario;
    }

    public List<Usuario> Ejecutar() => _repositorioUsuario.ListadoUsuarios();
    
}
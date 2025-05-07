using CentroEventos.Aplicacion;

public interface IUsuarioRepositorio {
    public void altaUsuario (Usuario usuario);
    public void bajaUsuario (int ID);
    public void modificacionUsuario (Usuario usuario); // (int ID)?;
    public List<Usuario> listarTodos();
}
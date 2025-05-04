namespace CentroEventos.Aplicacion;
public enum Permiso {
    ActividadAlta,
    ActividadModificacion,
    ActividadBaja,
    DeporteAlta,
    DeporteModificacion,
    DeporteBaja,
    InscripcionAlta,
    InscripcionModificacion,
    InscripcionBaja,
    UsuarioAlta,
    UsuarioModificacion,
    UsuarioBaja
}
public class Usuario {
    public string? email { get ; set; }
    public string? contrasenia { get ; set; }
    public string? nombre { get ; set; }
    public List<Permiso> permisos { get; set; } = [];

    public Usuario(string email, string contrasenia, string nombre)
    {
        this.email = email;
        this.contrasenia = contrasenia;
        this.nombre = nombre;
    }
}

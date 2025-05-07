namespace CentroEventos.Aplicacion;

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

    public override string ToString()
  {
    return $"{email} {contrasenia} {nombre}";
  }
}

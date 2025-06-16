public class Usuario
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? CorreoElectronico { get; set; }
    public string? Clave { get; set; }
    public List<Permiso> Permisos { get; set; } = new();


    public Usuario(string nombre, string apellido, string correoElectronico, string clave, List<Permiso> permisos)
    {
        Nombre = nombre;
        Apellido = apellido;
        CorreoElectronico = correoElectronico;
        Clave = clave;
        Permisos = permisos;
    } 
}
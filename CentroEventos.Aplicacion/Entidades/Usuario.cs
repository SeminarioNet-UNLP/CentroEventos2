public class Usuario
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? CorreoElectronico { get; set; }
    public string? Clave { get; set; }
    public List<Permiso> Permisos { get; set; } = new();


   public override string ToString()
    {
        return $"[{Id}] {Nombre} {Apellido} - {CorreoElectronico} - Permisos: {string.Join(", ", Permisos)}";
    }
}
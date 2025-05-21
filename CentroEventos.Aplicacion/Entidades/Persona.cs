public class Persona 
{
    public Persona(string dni, string? nombre, string? apellido, string? email, string? telefono)
    {
        Dni = dni;
        Nombre = nombre;
        Apellido = apellido;
        Email = email;
        Telefono = telefono;
    }
     
    public int Id { get; set; }
    public string Dni { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? Email { get; set; }
    public string? Telefono {get; set;}

    public override string ToString()
    {
        return $"{Id}#{Dni}#{Nombre}#{Apellido}#{Email}#{Telefono}";
    }

}
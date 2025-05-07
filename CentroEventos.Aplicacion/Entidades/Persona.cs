public abstract class Persona


{
    public Persona(int elId, int elDNI, string Nombre, string Apellido, string elEmail, string elTelefono)
    {
     id = elId;
     DNI=elDNI;
     nombre =Nombre;
     apellido =Apellido;
     telefono =elTelefono;
     email=elEmail;
    }

    public int id { get; set; }
    public int DNI { get; set; }
    public string? nombre { get; set; }
    public string? apellido { get; set; }
    public string? email { get; set; }
    public string? telefono {get; set;}

    public override string ToString()
    {
        return $"{id} {DNI} {nombre} {apellido} {telefono} {email}"; // hacer el to estring de una pesona
    }
}
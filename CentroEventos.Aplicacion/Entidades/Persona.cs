public abstract class Persona
{
    public Persona(int Id, int NumCarnet, string Nombre, string Apellido, string Direccion, string Facultad, string Telefono, string CorreoElectronico)
    {
     id = Id;
     numCarnet= NumCarnet; 
     nombre =Nombre;
     apellido =Apellido;
     direccion =Direccion;
     facultad =Facultad;
     telefono =Telefono;
     correoElectronico =CorreoElectronico;
    }

    public int id { get; set; }
    public int numCarnet { get; set; }
    public string? nombre { get; set; }
    public string? apellido { get; set; }
    public string? direccion { get; set; }
    public string? facultad { get; set; }
    public string? telefono {get; set;}
    public string? correoElectronico { get; set; }

    public override string ToString()
    {
        return $"{id} {numCarnet} {nombre} {apellido} {direccion} {facultad} {telefono} {correoElectronico}"; // hacer el to estring de una pesona
    }
}
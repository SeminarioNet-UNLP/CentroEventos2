public class Estudiante : Persona
{
    public Estudiante(int Id, int NumCarnet, string Nombre, string Apellido, string Direccion, string Facultad, string Telefono, string CorreoElectronico, int NumAlumno, string Carrera) : base(Id, NumCarnet, Nombre, Apellido, Direccion, Facultad, Telefono, CorreoElectronico)
    {
        numAlumno = NumAlumno;
        carrera = Carrera;
    }

    public int numAlumno { get; set; }
    public string? carrera{get; set;}
    public override string ToString()
    {
        return $"{base.ToString()} {numAlumno} {carrera}";
    }
}
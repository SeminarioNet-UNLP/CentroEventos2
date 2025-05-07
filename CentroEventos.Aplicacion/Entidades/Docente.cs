namespace CentroEventos.Aplicacion.Entidades
{
    public class Docente : Persona
    {
        public Docente(int Id, int NumCarnet, string Nombre, string Apellido, string Direccion, string Facultad, string Telefono, string CorreoElectronico, int Matricula, DateTime AnioIngreso) : base(Id, NumCarnet, Nombre, Apellido, Direccion, Facultad, Telefono, CorreoElectronico)
        {
            matricula = Matricula;
            anioIngreso = AnioIngreso;
        }

        public int matricula { get; set; }
        public DateTime anioIngreso { get; set; }
        public override string ToString()
        {
            return $"{base.ToString()} {matricula} {anioIngreso}";
        }
    }
}
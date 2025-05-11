namespace CentroEventos.Aplicaciones.Excepciones;
public class EntidadNotFoundException : Exception
{
    public EntidadNotFoundException(string mensaje) : base(mensaje) { }
    public EntidadNotFoundException(): base("Error de entidad: El ID del usuario o evento no existe.") { }
}
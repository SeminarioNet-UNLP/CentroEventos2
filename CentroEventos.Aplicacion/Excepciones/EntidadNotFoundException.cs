namespace CentroEventos.Aplicaciones.Excepciones;
public class EntidadNotFoundException : Exception
{
    public EntidadNotFoundException(string mensaje) : base(mensaje) { }
}
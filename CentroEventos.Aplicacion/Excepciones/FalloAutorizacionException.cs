namespace CentroEventos.Aplicaciones.Excepciones;
public class FalloAutorizacionException : Exception
{
    public FalloAutorizacionException(string mensaje) : base(mensaje) { }
    public FalloAutorizacionException(): base("Error de autorización: No tiene el permiso necesario.") { }
}
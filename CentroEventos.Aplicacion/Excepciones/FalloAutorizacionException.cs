namespace CentroEventos.Aplicaciones.Excepciones;
public class FalloAutorizacionException : Exception
{
    public FalloAutorizacionException(string mensaje) : base(mensaje) { }
}
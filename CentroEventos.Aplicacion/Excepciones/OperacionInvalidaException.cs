namespace CentroEventos.Aplicaciones.Excepciones;
public class OperacionInvalidaException : Exception
{
    public OperacionInvalidaException(string mensaje) : base(mensaje) { }
}
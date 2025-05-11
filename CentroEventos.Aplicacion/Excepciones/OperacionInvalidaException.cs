namespace CentroEventos.Aplicaciones.Excepciones;
public class OperacionInvalidaException : Exception
{
    public OperacionInvalidaException(string mensaje) : base(mensaje) { }
    public OperacionInvalidaException():
    base("Error de operacion: Operacion no permitida por la regla de negocio.") { }
}
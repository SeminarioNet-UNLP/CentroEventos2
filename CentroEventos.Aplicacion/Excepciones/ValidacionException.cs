namespace CentroEventos.Aplicaciones.Excepciones;
public class ValidacionException : Exception
{
    public ValidacionException(string mensaje) : base(mensaje) { }
}
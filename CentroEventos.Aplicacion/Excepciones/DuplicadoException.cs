namespace CentroEventos.Aplicaciones.Excepciones;
public class DuplicadoException : Exception
{
    public DuplicadoException(string mensaje) : base(mensaje) { }
}
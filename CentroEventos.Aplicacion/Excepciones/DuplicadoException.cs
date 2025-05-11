namespace CentroEventos.Aplicaciones.Excepciones;
public class DuplicadoException : Exception
{
    public DuplicadoException(string mensaje) : base(mensaje) { }
    public DuplicadoException():
    base("Error de duplicidad: Se intento crear una persona con DNI/email ya existente o reservar para la misma persona/actividad") { }
}
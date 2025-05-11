namespace CentroEventos.Aplicaciones.Excepciones;
public class ValidacionException : Exception
{
    public ValidacionException(string mensaje) : base(mensaje) { }
    public ValidacionException():
    base("Error de validacion: Algun dato obligatorio esta ausente o tiene formato incorrecto.") { }
}
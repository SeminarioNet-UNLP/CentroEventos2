namespace CentroEventos.Aplicaciones.Excepciones;
public class EntidadNotFoundException : Exception
{
    public EntidadNotFoundException(string mensaje) : base(mensaje) { }
    public EntidadNotFoundException():
    base("Error de operacion: El ID con el cual se intenta operar no existe") { }
}
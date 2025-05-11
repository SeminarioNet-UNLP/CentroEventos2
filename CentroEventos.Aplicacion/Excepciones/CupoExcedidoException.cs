namespace CentroEventos.Aplicaciones.Excepciones;
public class CupoExcedidoException : Exception
{
    public CupoExcedidoException(string mensaje) : base(mensaje) { }
    public CupoExcedidoException(): base("Error de cupo: Se alcanzo el limite maximo para el evento deportivo.") { }
}
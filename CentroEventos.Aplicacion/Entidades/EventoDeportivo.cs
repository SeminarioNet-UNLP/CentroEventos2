
public class EventoDeportivo
{
    public EventoDeportivo(string? nombre, string? descripcion, DateTime fechaHoraInicio,
                          double duracionHoras, int cupoMaximo, int responsableId)
    {
        Nombre = nombre;
        Descripcion = descripcion;
        FechaHoraInicio = fechaHoraInicio;
        DuracionHoras = duracionHoras;
        CupoMaximo = cupoMaximo;
        ResponsableId = responsableId;
    }

    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public DateTime FechaHoraInicio { get; set; }
    public double DuracionHoras { get; set; }
    public int CupoMaximo { get; set; }
    public int ResponsableId { get; set; }

    public override string ToString()
    {
        return $"{Id}#{Nombre}#{Descripcion}#{FechaHoraInicio}#{DuracionHoras}#{CupoMaximo}#{ResponsableId}";
    }
}
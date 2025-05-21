public class Reserva
{
    public Reserva (int personaId, int eventoDeportivoId, DateTime fechaAltaReserva, EstadosAsistencia estadoAsistencia)
    {
        PersonaId = personaId;
        EventoDeportivoId = eventoDeportivoId;
        FechaAltaReserva = fechaAltaReserva;
        EstadoAsistencia = estadoAsistencia;
    }

    public int Id { get; set; }
    public int PersonaId { get; set; }
    public int EventoDeportivoId { get; set; }
    public DateTime FechaAltaReserva { get; set; }
    public EstadosAsistencia EstadoAsistencia { get; set; }

    public override string ToString()
    {
        return $"{Id}#{PersonaId}#{EventoDeportivoId}#{FechaAltaReserva}#{EstadoAsistencia}";
    }
    
}
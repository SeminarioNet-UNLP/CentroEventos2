public class Reserva
{
    public Reserva (int id, int personaId, int eventoDeportivoId, DateTime fechaAltaReserva, EstadosAsistencia estadoAsistencia)
    {
        Id = id;
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
}
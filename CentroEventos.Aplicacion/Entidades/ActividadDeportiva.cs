public enum Deporte
{
    Futbol,
    Voley,
    Natacion,
    Basquet,
    Tenis,
    Rugby
}

public class ActividadDeportiva{
  public int id {get;set;}
  public Deporte deporte {get;set;}
  public List<DayOfWeek> diasDisponibles { get; set; } = new List<DayOfWeek>();
  public int cupoMax {get;set;}

  public ActividadDeportiva (int ElId, Deporte Depor,  List<DayOfWeek> dias, int Max){
    this.id=ElId;
    this.deporte=Depor;
    diasDisponibles=dias;
    this.cupoMax=Max;

  }
}
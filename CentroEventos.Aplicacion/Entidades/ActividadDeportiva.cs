public class ActividadDeportiva{
  public int id {get;set;}
  public Deporte deporte {get;set;}
  public List<DayOfWeek> diasDisponibles { get; set; } = new List<DayOfWeek>();
  public int cupoMax {get;set;}

 public ActividadDeportiva (int elId, Deporte depor,  List<DayOfWeek> dias, int Max)
 {
   this.id=elId;
   this.deporte=depor;
   diasDisponibles=dias;
   this.cupoMax=Max;
 }

}
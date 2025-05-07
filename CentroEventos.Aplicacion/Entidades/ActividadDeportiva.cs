public class ActividadDeportiva{
  public int id {get;set;}
  public Deporte deporte {get;set;}
  public List<DayOfWeek> diasDisponibles { get; set; } = new List<DayOfWeek>();
  public int cupoMax {get;set;}
  public int cantActual {get; set;}=0; //get disponible para todos, el set en cambio no. Se hace uno nuevo al hacer constructor
  public ActividadDeportiva (int elId, Deporte depor,  List<DayOfWeek> dias, int max){
    this.id=elId;
    this.deporte=depor;
    this.diasDisponibles=dias;
    this.cupoMax=max;

  }

  public override string ToString()
  {
    return $"{id} {cupoMax} {deporte} {diasDisponibles}";
  }

}
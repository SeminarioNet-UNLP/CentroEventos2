namespace CentroEventos.Aplicacion; 
public interface  IPersonaRepositorio
{
    public Persona ObtenenerPersona ();
    public void AgregarPersona(Persona p);
    public void ModificarPersona(Persona p);
    public void EliminiarPersona(int id);
    public List<Persona> ListarPersona();

}
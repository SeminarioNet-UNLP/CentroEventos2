namespace CentroEventos.Aplicacion; 
public interface  IPersonaRepositorio
{
    public Persona ObtenenerPersona (int id);
    public void AgregarPersona(Persona p);
    public void ModificarPersona(Persona p);
    public void EliminarPersona(int id);
    public List<Persona> ListarPersona();

}
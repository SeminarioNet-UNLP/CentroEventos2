

public interface IRepositorioPersona
{
    public void AltaPersona(Persona persona);
    public void ModificarPersona(Persona persona);
    public void BajaPersona(int id);
    public List<Persona> ListadoPersona();

}
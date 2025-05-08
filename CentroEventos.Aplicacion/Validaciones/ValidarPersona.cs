public class ValidarPersona
{

  public bool VerDatos(string nombre, string apellido , string Dni, string email)
{
    if (string.IsNullOrWhiteSpace(nombre))
        throw new Exception("Error. El nombre no puede estar vacio.");

    if (string.IsNullOrWhiteSpace(apellido))
        throw new Exception("Error. El apellido no puede estar vacia.");
    
    if (string.IsNullOrWhiteSpace(Dni))
        throw new Exception ("Error. El DNI no puede estar vacio.");

    if (string.IsNullOrWhiteSpace(email))
        throw new Exception ("Error. El email no puede estar vacio");     
    return true;
}

private readonly IRepositorioPersona _repoPersona;
    public ValidarPersona(IRepositorioPersona repoPersona)
    {
        _repoPersona = repoPersona;
    }
public bool DNINoSeRepite (string Dni)
{
    List<Persona> personas = _repoPersona.ListadoPersona();
    foreach (var persona in personas)
    {
      if (persona.Dni == Dni)
      {
        throw new Exception ("Error. Ya existe el DNI.");
      }
    }
    return true;
}

public bool EmailNoSeRepite (string Email)
{
    List<Persona> personas = _repoPersona.ListadoPersona();
    foreach (var persona in personas)
    {
      if (persona.Email == Email)
      {
        throw new Exception ("Error. Ya existe el Email.");
      }
    }
    return true;
}

}
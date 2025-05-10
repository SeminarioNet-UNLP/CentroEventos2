using CentroEventos.Aplicaciones.Excepciones;  // Este using es importante

namespace CentroEventos.Aplicaciones.Validaciones;
public class ValidarPersona
{

    private readonly IRepositorioPersona _repoPersona;
    public ValidarPersona(IRepositorioPersona repoPersona)
    {
        _repoPersona = repoPersona;
    }

    public bool VerDatos(string nombre, string apellido , string Dni, string email)
    {
        if (string.IsNullOrWhiteSpace(nombre))
            throw new ValidacionException("Error. El nombre no puede estar vacio.");

        if (string.IsNullOrWhiteSpace(apellido))
            throw new ValidacionException("Error. El apellido no puede estar vacia.");

        if (string.IsNullOrWhiteSpace(Dni))
            throw new ValidacionException ("Error. El DNI no puede estar vacio.");

        if (string.IsNullOrWhiteSpace(email))
            throw new ValidacionException ("Error. El email no puede estar vacio");     
        return true;
    }

    public bool DNINoSeRepite (string Dni)
    {
        List<Persona> personas = _repoPersona.ListadoPersona();
        foreach (var persona in personas)
        {
            if (persona.Dni == Dni)
            {
                throw new DuplicadoException ("Error. Ya existe el DNI.");
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
                throw new DuplicadoException ("Error. Ya existe el Email.");
            }
        }
        return true;
    }

}
using CentroEventos.Aplicaciones.Excepciones;  // Este using es importante

namespace CentroEventos.Aplicaciones.Validaciones;
public class ValidarPersona
{

    private readonly IRepositorioPersona _repoPersona;
    public ValidarPersona(IRepositorioPersona repoPersona)
    {
        _repoPersona = repoPersona;
    }

    public bool CamposVacios(string? nombre, string? apellido , string? Dni, string? email, out string mensajeError)
    {
        mensajeError = "";
        if (string.IsNullOrWhiteSpace(nombre))
            mensajeError = "Error. El nombre no puede estar vacio.";         

        if (string.IsNullOrWhiteSpace(apellido))
           mensajeError = "Error. El apellido no puede estar vacia.";

        if (string.IsNullOrWhiteSpace(Dni))
            mensajeError = "Error. El DNI no puede estar vacio.";

        if (string.IsNullOrWhiteSpace(email))
            mensajeError ="Error. El email no puede estar vacio";     
        return mensajeError == "";
    }

    public bool DNINoSeRepite (string? Dni, out string mensajeError)
    {
        mensajeError = "";
        List<Persona> personas = _repoPersona.ListadoPersona();
        foreach (var persona in personas)
        {
            if (persona.Dni == Dni)
            {
                mensajeError = "Error. Ya existe el DNI.";
            }
        }
        return mensajeError == "";
    }

    public bool EmailNoSeRepite (string? Email,out string mensajeError)
    {
        mensajeError = ""; 
        bool corte = false;
        List<Persona> personas = _repoPersona.ListadoPersona();

        for (int i = 0; i< personas.Count() && !corte; i++)
        {
            if (personas[i].Email == Email)
            {
                mensajeError= "Error. Ya existe el Email.";
                corte  = true;
            }
        }
        return mensajeError == "";
    }

}
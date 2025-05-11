using CentroEventos.Aplicaciones.Excepciones;
using CentroEventos.Aplicaciones.Validaciones;

public class AltaPersonaUseCase(IRepositorioPersona repo)
{
    private readonly IRepositorioPersona Repo = repo;

    public void Ejecutar(Persona persona)
    {
       string mensajeError;
       ValidarPersona validador = new ValidarPersona(Repo);
       if(!validador.CamposVacios(persona.Nombre??"", persona.Apellido??"", persona.Dni, persona.Email??"", out mensajeError))
       {
            throw new EntidadNotFoundException($"Error: {mensajeError}");
       }
       if(!validador.DNINoSeRepite(persona.Dni, out mensajeError))
       {
            throw new DuplicadoException($"Error: {mensajeError}");
       }
       if(!validador.EmailNoSeRepite(persona.Dni, out mensajeError))
       {
            throw new DuplicadoException($"Error: {mensajeError}");
       }
       try
       {
           Repo.AltaPersona(persona);
       }
       catch (Exception)
       {
           throw; // propaga la excepcion del metodo de alta
       }



        
    }
}

using CentroEventos.Aplicaciones.Excepciones;
using CentroEventos.Aplicaciones.Validaciones;

public class AltaPersonaUseCase
{

    private readonly IRepositorioPersona _repoPersona;

    private readonly IServicioAutorizacion _autorizador;

    public AltaPersonaUseCase(IRepositorioPersona repoPersona, IServicioAutorizacion autorizador)
    {

        _repoPersona = repoPersona;
        _autorizador = autorizador;
    }

    public void Ejecutar(Persona persona, int IdUsuario)
    {
        
            string mensajeError;
            ValidarPersona validador = new ValidarPersona(_repoPersona);
            if (!_autorizador.PoseeElPermiso(IdUsuario, Permiso.UsuarioAlta))
            {
                throw new FalloAutorizacionException();
            }
            
            if (!validador.CamposVacios(persona.Nombre, persona.Apellido, persona.Dni,persona.Email,out mensajeError))
            {
                throw new ValidacionException(mensajeError);
            }
            
            if (!validador.DNINoSeRepite(persona.Dni, out mensajeError))
            {
                throw new DuplicadoException(mensajeError);
            }
            
            if (!validador.EmailNoSeRepite(persona.Email,out mensajeError))
            {
                throw new DuplicadoException(mensajeError);
       
            }
       
        try
        {
            _repoPersona.AltaPersona(persona);
        }
        catch 
        {
            throw; //propaga la excepcion que se genero.
        }
    }
}
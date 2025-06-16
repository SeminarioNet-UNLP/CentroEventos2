using CentroEventos.Aplicaciones.Excepciones;
using CentroEventos.Aplicaciones.Validaciones;

public class ModificarPersonaUseCase
{
    private readonly IRepositorioPersona _repoPersona;
    private readonly IServicioAutorizacion _autorizador;
    private readonly ValidarPersona _validador;

    public ModificarPersonaUseCase(IRepositorioPersona repoPersona, IServicioAutorizacion autorizador, ValidarPersona validador)
    {
        _repoPersona = repoPersona;
        _autorizador = autorizador;
        _validador = validador;
    }

    public void Ejecutar(Persona persona, int IdUsuario)
    {
        string mensajeError;
        if (!_autorizador.PoseeElPermiso(IdUsuario, Permiso.UsuarioModificacion))
        {
            throw new FalloAutorizacionException();
        }

        if (!_validador.CamposVacios(persona.Nombre, persona.Apellido, persona.Dni,persona.Email, out mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }

        if (!_validador.EmailNoSeRepite(persona.Email, out mensajeError))
        {
            throw new DuplicadoException(mensajeError);
        }

        try
        {
            _repoPersona.ModificarPersona(persona);
        }
        catch
        {
            throw;
        }
    }

}
using CentroEventos.Aplicaciones.Excepciones;
using CentroEventos.Aplicaciones.Validaciones;

public class ModificarPersonaUseCase
{
    private readonly IRepositorioPersona _repoPersona;
    private readonly IServicioAutorizacion _autorizador;

    public ModificarPersonaUseCase(IRepositorioPersona repoPersona, IServicioAutorizacion autorizador)
    {
        _repoPersona = repoPersona;
        _autorizador = autorizador;
    }

    public void Ejecutar(Persona persona, int IdUsuario)
    {
        string mensajeError;
        ValidarPersona validador = new ValidarPersona(_repoPersona);

        if (!_autorizador.PoseeElPermiso(IdUsuario, Permiso.UsuarioModificacion))
        {
            throw new FalloAutorizacionException();
        }

        if (!validador.CamposVacios(persona.Nombre, persona.Apellido, persona.Dni,persona.Email, out mensajeError))
        {
            throw new ValidacionException(mensajeError);
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
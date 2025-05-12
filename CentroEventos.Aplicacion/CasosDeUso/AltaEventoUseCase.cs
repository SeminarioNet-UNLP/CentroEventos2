using CentroEventos.Aplicaciones.Excepciones;
using CentroEventos.Aplicaciones.Validaciones;

public class AltaEvento
{
    private readonly IRepositorioPersona _repoPersona;
    private readonly IServicioAutorizacion _autorizador;

    public AltaEvento (IRepositorioPersona repoPersona, IServicioAutorizacion autorizador)
    {
        _repoPersona = repoPersona;
        _autorizador = autorizador;
    }

    public void Ejecutar(EventoDeportivo eventoDeportivo, int IdUsuario)
    {
        // string mensajeError;
        ValidarEvento validador = new ValidarEvento(_repoPersona);
        try
        {
            if (!_autorizador.PoseeElPermiso(IdUsuario, Permiso.EventoAlta))
            {
                throw new FalloAutorizacionException();
            }
        }
        
        catch (FalloAutorizacionException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
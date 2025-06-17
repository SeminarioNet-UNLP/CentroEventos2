using CentroEventos.Aplicaciones.Excepciones;
using CentroEventos.Aplicaciones.Validaciones;

public class AltaEventoUseCase
{
    private readonly IRepositorioEventoDeportivo _repoEvento;
    private readonly IRepositorioPersona _repoPersona;
    private readonly IServicioAutorizacion _autorizador;
    private readonly ValidarEvento _validador;
    public AltaEventoUseCase(IRepositorioEventoDeportivo repoEvento,
                            IRepositorioPersona repoPersona,
                            IServicioAutorizacion autorizador, ValidarEvento validador)
    {
        _repoEvento = repoEvento;
        _repoPersona = repoPersona;
        _autorizador = autorizador;
        _validador = validador;
    }

    public void Ejecutar(EventoDeportivo eventoDeportivo, Usuario usuario)
    {
        string mensajeError;

        if (!_autorizador.PoseeElPermiso(usuario, Permiso.Administrador))
        {
            throw new FalloAutorizacionException();
        }

        if (!_validador.VerNombreYDescripcion(eventoDeportivo.Nombre, eventoDeportivo.Descripcion, out mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }
        
        if (!_validador.VerCupo(eventoDeportivo.CupoMaximo, out mensajeError))
         {
             throw new ValidacionException(mensajeError);
         }

        if (!_validador.VerFecha(eventoDeportivo.FechaHoraInicio,out mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }

        if (!_validador.VerHoras(eventoDeportivo.DuracionHoras, out mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }

        if (!_validador.VerResponsable(eventoDeportivo.ResponsableId, out mensajeError))
        {
            throw new EntidadNotFoundException(mensajeError);
        }

        try
        {
            _repoEvento.AltaEventoDeportivo(eventoDeportivo);
        }
        catch 
        {
            throw;
        }
    }
    
}
    
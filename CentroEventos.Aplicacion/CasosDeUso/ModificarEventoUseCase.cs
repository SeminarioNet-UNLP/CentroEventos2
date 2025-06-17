using System.Diagnostics;
using CentroEventos.Aplicaciones.Excepciones;
using CentroEventos.Aplicaciones.Validaciones;

public class ModificarEventoUseCase
{
    private readonly IRepositorioEventoDeportivo _repoEvento;
    private readonly IRepositorioPersona _repoPersona;
    private readonly IServicioAutorizacion _autorizador;
    private readonly ValidarEvento _validador;

    public ModificarEventoUseCase(IRepositorioEventoDeportivo repoEvento,
                                  IRepositorioPersona repoPersona,
                                  IServicioAutorizacion autorizador,
                                  ValidarEvento validador)
    {
        _repoEvento = repoEvento;
        _repoPersona = repoPersona;
        _autorizador = autorizador;
        _validador = validador;
    }

    public void Ejecutar(EventoDeportivo eventoDeportivo, Usuario usuario)
    {
        string mensajeError;
        List<EventoDeportivo> eventos = _repoEvento.ListadoEventoDeportivo();

        if (!_autorizador.PoseeElPermiso(usuario, Permiso.Administrador))
        {
            throw new FalloAutorizacionException();
        }

        if (eventos != null)
        {
            bool condi = false;
            for (int i = 0; i < eventos.Count() && !condi; i++)
            {
                if (eventos[i].Id == eventoDeportivo.Id && eventos[i].FechaHoraInicio < DateTime.Now)
                {
                    throw new OperacionInvalidaException("No se puede modificar un evento. Ya expiro");
                }
            }    
        }

        if (!_validador.VerNombreYDescripcion(eventoDeportivo.Nombre, eventoDeportivo.Descripcion, out mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }

        if (!_validador.VerCupo(eventoDeportivo.CupoMaximo, out mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }

        if (!_validador.VerFecha(eventoDeportivo.FechaHoraInicio, out mensajeError))
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
            _repoEvento.ModificarEventoDeportivo(eventoDeportivo);
        }
        catch
        {
            throw;
        }
    }
    
}

using System.Diagnostics;
using CentroEventos.Aplicaciones.Excepciones;
using CentroEventos.Aplicaciones.Validaciones;

public class ModificarEventoUseCase
{
    private readonly IRepositorioEventoDeportivo _repoEvento;
    private readonly IRepositorioPersona _repoPersona;
    private readonly IServicioAutorizacion _autorizador;

    public ModificarEventoUseCase(IRepositorioEventoDeportivo repoEvento,
                         IRepositorioPersona repoPersona,
                         IServicioAutorizacion autorizador)
    {
        _repoEvento = repoEvento;
        _repoPersona = repoPersona;
        _autorizador = autorizador;
    }

    public void Ejecutar(EventoDeportivo eventoDeportivo, int IdUsuario)
    {
        string mensajeError;
        ValidarEvento validador = new ValidarEvento(_repoPersona);
        List<EventoDeportivo> eventos = _repoEvento.ListadoEventoDeportivo();
        if (!_autorizador.PoseeElPermiso(IdUsuario, Permiso.EventoModificacion))
        {
            throw new FalloAutorizacionException();
        }
        if (eventos != null) // validacion No se puede modificar un envento que ya expiro
        {
            bool condi=false;
            for (int i = 0; i < eventos.Count() && !condi; i++)
            {
                if(eventos[i].ResponsableId == eventoDeportivo.ResponsableId && eventos[i].FechaHoraInicio< DateTime.Now)
                {
                    throw new OperacionInvalidaException("No se puede modificar un evento. Ya expiro");
                }
            }    
        }
        if (!validador.VerNombreYDescripcion(eventoDeportivo.Nombre, eventoDeportivo.Descripcion, out mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }
        if (!validador.VerCupo(eventoDeportivo.CupoMaximo, out mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }
        if (!validador.VerFecha(eventoDeportivo.FechaHoraInicio, out mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }
        if (!validador.VerHoras(eventoDeportivo.DuracionHoras, out mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }
        if (!validador.VerResponsable(eventoDeportivo.ResponsableId, out mensajeError))
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

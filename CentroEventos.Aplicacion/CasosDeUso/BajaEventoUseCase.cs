using CentroEventos.Aplicaciones.Excepciones;
using CentroEventos.Aplicaciones.Validaciones;

public class   BajaEventoUseCase
{
private readonly IRepositorioEventoDeportivo _repoEvento;
private readonly IRepositorioPersona _repoPersona;
private readonly IServicioAutorizacion _autorizador;

public BajaEventoUseCase(IRepositorioEventoDeportivo repoEvento,
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
        try
        {
            if (!_autorizador.PoseeElPermiso(IdUsuario, Permiso.EventoBaja))
            {
                throw new FalloAutorizacionException();
            }

            if (!validador.VerCupo(eventoDeportivo.CupoMaximo,out mensajeError))
            {
                throw new ValidacionException(mensajeError);
            }
        
            if (!validador.VerFecha(eventoDeportivo.FechaHoraInicio,out mensajeError))
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
        }

        catch (FalloAutorizacionException e)
        {
            Console.WriteLine($"Error de autorización: {e.Message}");
        }
        catch (ValidacionException e)
        {
            Console.WriteLine($"Error de validación: {e.Message}");
        }
        catch (EntidadNotFoundException e)
        {
            Console.WriteLine($"Entidad no encontrada: {e.Message}");
        }
        try
            {
                _repoEvento.BajaEventoDeportivo(eventoDeportivo.Id);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al dar de baja el evento: {e.Message}");
            }
        }
    }
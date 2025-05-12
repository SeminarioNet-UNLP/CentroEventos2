using CentroEventos.Aplicaciones.Excepciones;
using CentroEventos.Aplicaciones.Validaciones;

public class ModificarReservaUseCase
{
    private readonly IRepositorioReserva _repoReserva;
    private readonly IRepositorioPersona _repoPersona;
    private readonly IRepositorioEventoDeportivo _repoEventoDeportivo;
    private readonly IServicioAutorizacion _autorizador;

    public ModificarReservaUseCase(IRepositorioReserva repoReserva, 
                              IRepositorioPersona repoPersona, 
                              IRepositorioEventoDeportivo repoEventoDeportivo,
                              IServicioAutorizacion autorizador)
    {
        _repoReserva = repoReserva;
        _repoPersona = repoPersona;
        _repoEventoDeportivo = repoEventoDeportivo;
        _autorizador = autorizador; 
    }

    public void Ejecutar(Reserva reserva, int IdUsuario)
    {
        try
        {
            string mensajeError;
            ValidarReserva validador = new ValidarReserva(_repoPersona, _repoEventoDeportivo, _repoReserva);
            if (!_autorizador.PoseeElPermiso(IdUsuario, Permiso.ReservaModificacion))
            {
                throw new FalloAutorizacionException();
            }
            
            if (!validador.ExistenPersonaYEvento(reserva.PersonaId, reserva.EventoDeportivoId, out mensajeError))
            {
                throw new EntidadNotFoundException(mensajeError);
            }

            if (!validador.VerificarReservaExistente(reserva, out mensajeError))
            {
                throw new CupoExcedidoException(mensajeError);
            }

            if (!validador.VerificarCupoDisponible(reserva.EventoDeportivoId, out mensajeError))
            {
                throw new DuplicadoException(mensajeError);
            }
        }
         catch (FalloAutorizacionException e)
        {
            Console.WriteLine($"Error, no tiene permiso para ejecutar la accion :{e.Message}");
        }
        catch (EntidadNotFoundException e)
        {
            Console.WriteLine($"Hubo un error, no se encontro:{e.Message}");
        }
        catch (CupoExcedidoException e)
        {
            Console.WriteLine($"Error, cupo excedido: {e.Message}");
        }
        catch (DuplicadoException e)
        {
            Console.WriteLine($"Hubo un error, datos duplicados:{e.Message}");
        }
        // Revisar este último try/catch
        try
        {
            _repoReserva.ModificarReserva(reserva);
        }
        catch (Exception e)
        {
            Console.WriteLine($"No se pudo modificar la reserva: {e.Message}");
        }
    }
} 

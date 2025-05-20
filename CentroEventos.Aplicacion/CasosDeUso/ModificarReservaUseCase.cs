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
      if (!validador.VerificarCupoDisponible(reserva.EventoDeportivoId, out mensajeError))
      {
          throw new DuplicadoException(mensajeError);
      }
      try
      {
        _repoReserva.ModificarReserva(reserva);
      }    
      catch
      {
        throw;
      }  
    }
}

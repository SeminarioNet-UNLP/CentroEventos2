using CentroEventos.Aplicaciones.Excepciones;
using CentroEventos.Aplicaciones.Validaciones;

public class BajaPersonaUseCase
{

    private readonly IRepositorioPersona _repoPersona;

    private readonly IServicioAutorizacion _autorizador;
  private readonly IRepositorioEventoDeportivo _repoEvento;
  private readonly IRepositorioReserva _repoReserva;
    public BajaPersonaUseCase(IRepositorioPersona repoPersona,IRepositorioEventoDeportivo repoEvento,IRepositorioReserva repoReserva,IServicioAutorizacion autorizador)
  {
    _repoEvento = repoEvento;
    _repoReserva = repoReserva;
    _repoPersona = repoPersona;
    _autorizador = autorizador;
  }

    public void Ejecutar(int IdEliminar, int IdUsuario)
    {
      List<EventoDeportivo> todosEventos = _repoEvento.ListadoEventoDeportivo();
      List<Reserva> todasReservas = _repoReserva.ListadoReserva();
      if (!_autorizador.PoseeElPermiso(IdUsuario, Permiso.UsuarioBaja))
      {
        throw new FalloAutorizacionException();
      }
      if (todosEventos != null)
      {
        foreach (EventoDeportivo e in todosEventos)
        {
          if (e.ResponsableId == IdEliminar)
          {
            throw new OperacionInvalidaException("No se puede dar de baja una persona que es responsable");
          }
        }
      }
      if(todasReservas != null)
      { 
        foreach (Reserva r in todasReservas)
        {
          if (r.PersonaId == IdEliminar)
          { 
              throw new OperacionInvalidaException("No se puede dar de baja una persona que tenga una reserva");
          }
        } 
      }
      
      try
      {
        _repoPersona.BajaPersona(IdEliminar);
      }
      catch
      {
        throw;
      }
    }
}
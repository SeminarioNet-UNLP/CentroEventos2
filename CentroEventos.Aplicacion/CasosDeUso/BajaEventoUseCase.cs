using CentroEventos.Aplicaciones.Excepciones;
using CentroEventos.Aplicaciones.Validaciones;

    public class  BajaEventoUseCase
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

    public void Ejecutar(IRepositorioReserva _repoReserva,int IdEliminar, Usuario usuario)
    {
        List<Reserva> reservas = _repoReserva.ListadoReserva();      

        if (!_autorizador.PoseeElPermiso(usuario, Permiso.Administrador))
        {
            throw new FalloAutorizacionException();
        }

        if (reservas != null)
        {
            for (int i = 0; i < reservas.Count(); i++)
            {
                if (reservas[i].EventoDeportivoId == IdEliminar)
                {
                    throw new OperacionInvalidaException("El evento tiene reservas asignadas");
                }
            }   
        }    
           
        try
        {
            _repoEvento.BajaEventoDeportivo(IdEliminar);
        }
        catch
        {
            throw;
        }
    }
    
} 

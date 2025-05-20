using CentroEventos.Aplicaciones.Excepciones;
using CentroEventos.Aplicaciones.Validaciones;

public class BajaReservaUseCase
{
    private readonly IRepositorioReserva _repoReserva;
    private readonly IRepositorioPersona _repoPersona;
    private readonly IRepositorioEventoDeportivo _repoEventoDeportivo;
    private readonly IServicioAutorizacion _autorizador;

    public BajaReservaUseCase(IRepositorioReserva repoReserva, 
                              IRepositorioPersona repoPersona, 
                              IRepositorioEventoDeportivo repoEventoDeportivo,
                              IServicioAutorizacion autorizador)
    {
        _repoReserva = repoReserva;
        _repoPersona = repoPersona;
        _repoEventoDeportivo = repoEventoDeportivo;
        _autorizador = autorizador;
    }

    public void Ejecutar(int idElimiar, int IdUsuario)
    {
        bool condi = false;
       List<Reserva> reservas = _repoReserva.ListadoReserva();
       ValidarReserva validador = new ValidarReserva(_repoPersona, _repoEventoDeportivo, _repoReserva);
       if (!_autorizador.PoseeElPermiso(IdUsuario, Permiso.ReservaBaja))
       {
           throw new FalloAutorizacionException();
       }
        if (reservas != null)
        {
            for (int i = 0; i < reservas.Count() && !condi; i++)
            {
                if (reservas[i].Id == idElimiar)
                {
                    condi = true;
                }
            }
            if (!condi)
            {
                throw new EntidadNotFoundException($"No se encontro la reserva con el id = {idElimiar}");
            }
        }
        else
        {
            throw new Exception("no hay reservas para eliminar");
        }
       try
        {
            _repoReserva.BajaReserva(idElimiar);
        }
        catch
        {
            throw;
        }
    }
}
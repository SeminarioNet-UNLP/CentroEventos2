using System.Diagnostics;
using CentroEventos.Aplicaciones.Excepciones;  // Este using es importante

namespace CentroEventos.Aplicaciones.Validaciones;
public class ValidarReserva
{
    private readonly IRepositorioPersona _repoPersona;
    private readonly IRepositorioEventoDeportivo _repoEventoDeportivo;
    private readonly IRepositorioReserva _repoReserva;
    public ValidarReserva (IRepositorioPersona repoPersona, IRepositorioEventoDeportivo repoEventoDeportivo, IRepositorioReserva repoReserva)
    {
        _repoPersona = repoPersona;
        _repoEventoDeportivo = repoEventoDeportivo;
        _repoReserva = repoReserva;

    }
    public bool ExistenPersonaYEvento(int IdPersona, int IdEvento, out string mensajeError)
    {
        mensajeError = "";
        List<Persona> personas = _repoPersona.ListadoPersona();
        List<EventoDeportivo> eventos = _repoEventoDeportivo.ListadoEventoDeportivo();
        bool existePersona = false;
        bool existeEvento = false;
        for (int i = 0; i < personas.Count() && !existePersona ; i++)
        {
            if(personas[i].Id == IdPersona)
            {   
                existePersona = true;
            }
        }
        for (int i = 0; i < eventos.Count() && !existeEvento ; i++)
        {
            if(eventos[i].Id == IdEvento)
            {   
                existeEvento = true;
            }
        }
        if (!existePersona)
        {
            mensajeError += "Error. Persona no encontrada.";
        }
        if(!existeEvento)
        {
            mensajeError += "Error. Evento no encontrado";
        }
        return mensajeError == "";
    }

    public bool VerificarReservaExistente(Reserva reserva, out string mensajeError)
    {
        mensajeError = "";
        List<Reserva> reservas = _repoReserva.ListadoReserva();
        bool reservaEncontrada = false;
        if(reservas != null)
        {
            for (int i=0; i < reservas.Count() && !reservaEncontrada; i++)
            {
                reservaEncontrada = (reservas[i].PersonaId == reserva.PersonaId) &&
                                    (reservas[i].EventoDeportivoId == reserva.EventoDeportivoId);    
            }
            if (reservaEncontrada)
            {   
                mensajeError = "No se puede reservar dos veces el mismo evento.";
            }
        }
        else
        {
            mensajeError = "No se encuentran reservas.";
        }
        return mensajeError == "";
    }

    public bool VerificarCupoDisponible(int eventoId, out string mensajeError) // 
    {
        mensajeError = "";
        EventoDeportivo? eventoEncontrado = null;

        foreach (var evento in _repoEventoDeportivo.ListadoEventoDeportivo())
        {
            if (evento.Id == eventoId)
            {
                eventoEncontrado = evento;
                break;
            }
        }

        if (eventoEncontrado == null)
        {
            mensajeError = "Error. El evento no existe.";
        }
        else
        {
            int cantidadReservas = 0;
            List<Reserva> reservas = _repoReserva.ListadoReserva();
            if (reservas != null)
            { 
                foreach (Reserva r in reservas)
                {
                    if (r.EventoDeportivoId == eventoId)
                    {
                        cantidadReservas++;
                    }
                }
            }
            if (cantidadReservas+1 >= eventoEncontrado.CupoMaximo)
            {
                mensajeError = "Error. No hay cupo disponible para este evento.";
            }
        }

        return mensajeError == "";
    }
}
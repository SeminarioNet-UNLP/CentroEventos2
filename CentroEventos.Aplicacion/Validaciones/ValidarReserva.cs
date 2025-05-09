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

}
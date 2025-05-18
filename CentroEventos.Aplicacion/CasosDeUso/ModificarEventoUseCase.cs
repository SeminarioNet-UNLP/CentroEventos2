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
        ValidarEvento validador = new ValidarEvento(_repoPersona);
        List<string> errores = new List<string>();

        if (!_autorizador.PoseeElPermiso(IdUsuario, Permiso.EventoBaja))
            throw new FalloAutorizacionException();

        string mensajeError;

        if (!validador.VerCupo(eventoDeportivo.CupoMaximo, out mensajeError))
            errores.Add(mensajeError);

        if (!validador.VerFecha(eventoDeportivo.FechaHoraInicio, out mensajeError))
            errores.Add(mensajeError);

        if (!validador.VerHoras(eventoDeportivo.DuracionHoras, out mensajeError))
            errores.Add(mensajeError);

        if (!validador.VerResponsable(eventoDeportivo.ResponsableId, out mensajeError))
            errores.Add(mensajeError);

        if (errores.Count > 0)
        {
            string erroresTotales = "";
            foreach (string error in errores)
            {
                erroresTotales += error + "\n";
            }
            throw new ValidacionException(erroresTotales);
        }
    }
}

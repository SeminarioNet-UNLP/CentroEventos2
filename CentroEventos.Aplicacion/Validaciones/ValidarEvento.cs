using CentroEventos.Aplicaciones.Excepciones;

namespace CentroEventos.Aplicaciones.Validaciones;

public class ValidarEvento
{
    private readonly IRepositorioPersona _repoPersona;

    public ValidarEvento(IRepositorioPersona repoPersona)
    {
        _repoPersona = repoPersona;
    }
    
    public bool VerNombreYDescripcion(string? nombre, string? descripcion, out string mensajeError)
    {
        mensajeError = "";
        
        if (string.IsNullOrWhiteSpace(nombre))
            mensajeError = "Error. El nombre no puede estar vacio.";
        if (string.IsNullOrWhiteSpace(descripcion))
            mensajeError = "Error. La descripcion no puede estar vacia.";
        return mensajeError == "";
    }

    public bool VerFecha (DateTime? fechaHoraInicio, out string mensajeError)
    {
        mensajeError = "";
        if (fechaHoraInicio <= DateTime.Now)
            mensajeError = "Error. La fecha de la actividad debe ser mayor a la fecha actual.";
        return mensajeError == "";
    }

    public bool VerCupo (int? cupoMaximo, out string mensajeError)
    {
        mensajeError = "";
        if (cupoMaximo < 1)
            mensajeError = "Error. El cupo maximo debe ser mayor a cero.";
        return mensajeError == "";
    }

    public bool VerHoras (double? duracionHoras, out string mensajeError)
    {
        mensajeError = "";
        if (duracionHoras < 1)
            mensajeError = "Error. La duracion de las horas debe ser mayor a cero.";
        return mensajeError == ""; 
    }

    public bool VerResponsable(int? responsableId, out string mensajeError)
    {
        List<Persona> personas = _repoPersona.ListadoPersona();
        foreach (var persona in personas)
        {
            if (persona.Id == responsableId)
            {
                mensajeError = "El responsable existe.";
                return true;
            }
        }
        mensajeError = "Error. El ID del responsable no corresponde a ninguna persona registrada.";
        return false;
    }

}
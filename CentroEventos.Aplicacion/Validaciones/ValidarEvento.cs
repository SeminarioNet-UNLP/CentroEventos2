using CentroEventos.Aplicaciones.Excepciones;  // Este using es importante

namespace CentroEventos.Aplicaciones.Validaciones;
public class ValidarEvento

{

    public bool VerNombreYDescripcion(string nombre, string descripcion)
    {
        if (string.IsNullOrWhiteSpace(nombre))
            throw new ValidacionException("Error. El nombre no puede estar vacio.");

        if (string.IsNullOrWhiteSpace(descripcion))
            throw new ValidacionException("Error. La descripcion no puede estar vacia.");

        return true;
    }

    public bool VerFecha (DateTime fechaHoraInicio)
    {
        if (fechaHoraInicio <= DateTime.Now) // Más fácil, para no crear una variable de fechaActual
            throw new ValidacionException ("Error. La fecha de la actividad debe ser mayor a la fecha actual.");

        return true;   
    }

    public bool VerCupo (int cupoMaximo)
    {
        if (cupoMaximo<1)
            throw new ValidacionException ("Error. El cupo maximo debe ser mayor a cero.");
        
        return true;    
    }

    public bool VerHoras (double duracionHoras)
    {
        if (duracionHoras<1)
            throw new ValidacionException ("Error. La duracion de las horas debe ser mayor a cero.");
        
        return true; 
    }

    private readonly IRepositorioPersona _repoPersona;

        public ValidarEvento(IRepositorioPersona repoPersona)
        {
            _repoPersona = repoPersona;
        }

    public bool VerResponsable(int responsableId)
    {
        List<Persona> personas = _repoPersona.ListadoPersona();

        foreach (var persona in personas)
        {
            if (persona.Id == responsableId)
            {
                return true;
            }
        }

        throw new EntidadNotFoundException("Error. El ID del responsable no corresponde a ninguna persona registrada.");
    }

}
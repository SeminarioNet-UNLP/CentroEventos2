using System.Reflection.Metadata.Ecma335;
public class ValidarEvento

{

public bool VerNombreYDescripcion(string nombre, string descripcion)
{
    if (string.IsNullOrWhiteSpace(nombre))
        throw new Exception("Error. El nombre no puede estar vacio.");

    if (string.IsNullOrWhiteSpace(descripcion))
        throw new Exception("Error. La descripcion no puede estar vacia.");

    return true;
}

public static readonly DateTime fechaAct = new DateTime(2025, 5, 22); //Elegi ese dia como referencia, si quieren la cambiamos

public bool VerFecha (DateTime fechaHoraInicio)
{
   if (fechaHoraInicio<=fechaAct)
      throw new Exception ("Error. La fecha de la actividad debe ser mayor a la fecha actual.");
   
   return true;   
}

public bool VerCupo (int cupoMaximo)
{
  if (cupoMaximo<1)
     throw new Exception ("Error. El cupo maximo debe ser mayor a cero.");
  
  return true;    
}

public bool VerHoras (double duracionHoras)
{
  if (duracionHoras<1)
     throw new Exception ("Error. La duracion de las horas debe ser mayor a cero.");
  
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

    throw new Exception("Error. El ID del responsable no corresponde a ninguna persona registrada.");
}

}
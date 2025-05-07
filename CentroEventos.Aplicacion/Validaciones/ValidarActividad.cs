using System.ComponentModel.DataAnnotations;

public static class ValidarActividad
{
  public static bool CampoVacio (string campo)
  {
     if (campo==null)
     {
         throw new Exception ("Error. Debe ingresar su nombre.");
     }
     else
     {
        return true; 
     }
     
  }
private static readonly DateTime fechaMinima = new DateTime(2025, 5, 19); 
//quise tomar como referencia esta fecha, si no hacemos fecha>DateTime.Today y fue, como mejor les parezca
//debo comparar usando los dias disponibles?? consultar... Lo hice asi. No veo otra forma de comparar con la fechaMinima
   
   // public static bool VerFecha(List<DayOfWeek> diasDisponibles)
   // {
   //     for (int i=0;i<diasDisponibles.Count;i++){
   //     DateTime dia = diasDisponibles[i].DateTime();
   //     if (dia < fechaMinima)
   //     {
   //         throw new ValidationException($"La fecha debe ser igual o posterior a {fechaMinima.ToString()}.");
   //     }
   //     else
   //     {
   //     return true;
   //     }
   //   }
   // }

    public static bool VerCupo (int cupoMax)    
    {
      if (cupoMax<1)
      {
        throw new Exception ($"El cupo maximo debe ser mayor a cero.");
      }
      else
      {
        return true;
      }
    }

}
  

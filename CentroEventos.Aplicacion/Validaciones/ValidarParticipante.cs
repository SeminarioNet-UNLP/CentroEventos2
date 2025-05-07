public static class ValidarParticipante 
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

  public static bool DNINoSeRepite (int numCarnet) //Porque dni?? si de la persona no se sabe dni... quizas se refiere al carnet.
  {
      List<Persona> personas= new List<Persona>();
      foreach (var persona in personas)
      {
           if (persona.numCarnet==numCarnet)
           {
               throw new Exception ("Error. El DNI ya existe en el sistema.");
           }
      }               
              return true;         
   }    

  }


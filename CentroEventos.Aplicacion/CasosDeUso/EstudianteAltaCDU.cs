using CentroEventos.Aplicacion;

public class EstudianteAltaCDU : PersonaCDU
{
    public EstudianteAltaCDU(IPersonaRepositorio Repositorio) : base(Repositorio)
    {
    }
    public void Ejecutar(Estudiante e)
    {

       try{
          ValidarParticipante.CampoVacio(e.nombre ?? ""); //puse eso de ?? xq sino me tiraba linea amarillo diciendo que quizas era null
          ValidarParticipante.DNINoSeRepite(e.numCarnet);
          repositorio.AgregarPersona(e);          
          } 
        catch (Exception a)
        {
            throw new Exception ($"Se produjo un error {a.Message}");
        }  

        repositorio.AgregarPersona(e);

    }
    
}
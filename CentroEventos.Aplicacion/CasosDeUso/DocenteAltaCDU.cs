using CentroEventos.Aplicacion;
using CentroEventos.Aplicacion.Entidades; // Pablo 7/5: esto es innecesario, entidades ya forma parte de aplicacion

public class DocenteAltaCDU : PersonaCDU
{
    public DocenteAltaCDU(IPersonaRepositorio Repositorio) : base(Repositorio)
    {
    }
    public void Ejecutar(Docente d)
    {
       try{
          ValidarParticipante.CampoVacio(d.nombre ?? ""); //puse eso de ?? xq sino me tiraba linea amarillo diciendo que quizas era null
          ValidarParticipante.DNINoSeRepite(d.numCarnet);
          repositorio.AgregarPersona(d);          
          } 
        catch (Exception a)
        {
            throw new Exception ($"Se produjo un error {a.Message}");
        }  
    }
    
}
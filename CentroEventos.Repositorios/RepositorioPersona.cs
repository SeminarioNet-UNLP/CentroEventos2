using CentroEventos.Aplicaciones.Excepciones;

public class RepositorioPersona : IRepositorioPersona
{
    private const int CantPropsPersona = 6;
    private readonly string rutaIDs = "IdPersona.txt";
    private readonly string archivoPersonas = "PersonasPersistencia.txt";
    public void AltaPersona(Persona persona)
    {
        string mensajeError;
        int ultimoId = IdManager.BuscarUltimoId(rutaIDs, out mensajeError);
        if (ultimoId >= 0)
        {
            persona.Id = ultimoId + 1;
            try
            {
                using (StreamWriter sw = new StreamWriter(archivoPersonas, true))
                {
                    sw.WriteLine(persona.ToString());
                }
                IdManager.ActualizarArchivoId(rutaIDs, persona.Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        else
        {
            throw new Exception($"Error: {mensajeError}");
        }
    }

    public void BajaPersona(int id)
    {
        bool encontrePersona = false;
        List<Persona> personas = ListadoPersona();
        for (int i = 0; i < personas.Count() && !encontrePersona; i++)
        {
            if (personas[i].Id == id)
            {
                personas.RemoveAt(i);
                encontrePersona = true;
            }
        }
        if (encontrePersona)
        {
            RemplazarPersonas(personas);
        }
        else
        {
            throw new EntidadNotFoundException("No se encontro el id correspondiente");
        }
    }

    public List<Persona> ListadoPersona()
    {
        using (var context = new CentroEventosContext())
        {
            return context.Personas.ToList();
        }
        
    }

    public void ModificarPersona(Persona persona)
    {
        List<Persona> personas = ListadoPersona();
        bool encontrePersona = false;
        if (personas != null)
        {
            for (int i = 0; i < personas.Count() && !encontrePersona; i++)
            {
                if (personas[i].Dni == persona.Dni)
                {
                    persona.Id = personas[i].Id; // La persona que ingresa no tiene ID por el momento
                    personas[i] = persona;
                    encontrePersona = true;
                }
            }
            if (encontrePersona)
            {
                RemplazarPersonas(personas);
            }
            else
            {
                throw new EntidadNotFoundException("No se encontro el id correspondiente");
            }
        }
    }

    private void RemplazarPersonas(List<Persona> persona)
    {
        using (StreamWriter sw = new StreamWriter(archivoPersonas))
        {
            foreach (Persona per in persona)
            {
                sw.WriteLine(per.ToString());
            }
        }
    }
    
}


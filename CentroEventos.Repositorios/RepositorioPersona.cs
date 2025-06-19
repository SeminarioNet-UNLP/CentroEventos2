using CentroEventos.Aplicaciones.Excepciones;

public class RepositorioPersona : IRepositorioPersona
{
   
    public void AltaPersona(Persona persona)
    {
        if (persona != null)
        {
            
            try
            {
                using (var context = new CentroEventosContext())
                {
                    context.Personas.Add(persona);
                    context.SaveChanges();
                }
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        else
        {
            throw new Exception($"Error: no puede estar vacia la persona");
        }
    }

    public void BajaPersona(int id)
    {
        using (var context = new CentroEventosContext())
        {
            var PersonaEliminar = context.Personas.FirstOrDefault(p => p.Id == id);
            if (PersonaEliminar != null)
            {
                context.Personas.Remove(PersonaEliminar);
                context.SaveChanges();
            }
            else
            {
                throw new EntidadNotFoundException("No se encontro el id correspondiente");
            }
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
        using (var context = new CentroEventosContext())
        {
            var PersonaModificar = context.Personas.FirstOrDefault(p => p.Id == persona.Id);
            if (PersonaModificar != null)
            {
                PersonaModificar.Nombre = persona.Nombre;
                PersonaModificar.Apellido = persona.Apellido;
                PersonaModificar.Dni = persona.Dni;
                PersonaModificar.Telefono = persona.Telefono;
                PersonaModificar.Email = persona.Email;

                context.SaveChanges();
            }
            else
            {
                throw new EntidadNotFoundException("No se encontro el id correspondiente");
            }
        }
    }

    
}


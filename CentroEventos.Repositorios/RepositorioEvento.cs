using System.Diagnostics.Tracing;
using CentroEventos.Aplicaciones.Excepciones;

public class RepositorioEventoDeportivo : IRepositorioEventoDeportivo
{
    private const int CantPropsPersona = 7;
    private readonly string rutaIDs = "IdEventosDeportivos.txt";
    private readonly string archivoEventos = "EventoPersistencia.txt";

    public void AltaEventoDeportivo(EventoDeportivo evento)
    {
        string mensajeError;
        int ultimoId = IdManager.BuscarUltimoId(rutaIDs, out mensajeError);
        if (ultimoId >= 0)
        {
            evento.Id = ultimoId + 1;
            try
            {
                using (StreamWriter sw = new StreamWriter(archivoEventos, true))
                {
                    sw.WriteLine(evento.ToString());
                }
                IdManager.ActualizarArchivoId(rutaIDs, evento.Id);
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

    public void BajaEventoDeportivo(int id)
    {
        bool encontreEvento = false;
        List<EventoDeportivo> eventos = ListadoEventoDeportivo();
        for (int i = 0; i < eventos.Count() && !encontreEvento; i++)
        {
            if (eventos[i].Id == id)
            {
                eventos.RemoveAt(i);
                encontreEvento = true;
            }
        }
        if (encontreEvento)
        {

            RemplazarEventos(eventos);
        }
        else
        {
            throw new EntidadNotFoundException("No se encontro el id correspondiente");
        }
    }

    public List<EventoDeportivo> ListadoEventoDeportivo()
    {
        List<EventoDeportivo> eventos = new List<EventoDeportivo>();
        try
        {
            using (StreamReader sr = new StreamReader(archivoEventos))
            {
                string? lineaP;
                while (!sr.EndOfStream && (lineaP = sr.ReadLine()) != null)
                {
                    string[] campos = lineaP.Split("#");
                    if (campos.Length == CantPropsPersona)
                    {
                        EventoDeportivo even = new EventoDeportivo(
                            campos[1],
                            campos[2],
                            DateTime.Parse(campos[3]),
                            double.Parse(campos[4]),
                            int.Parse(campos[5]),
                            int.Parse(campos[6])
                        );
                        even.Id = int.Parse(campos[0]);
                        eventos.Add(even);
                    }
                }
            }
        }
        catch 
        {
            return eventos;
        }
        return eventos;
    }

    public void ModificarEventoDeportivo(EventoDeportivo evento)
    {
        List<EventoDeportivo> eventos = ListadoEventoDeportivo();
        bool encontreEvento = false;
        if (eventos != null)
        {
            for (int i = 0; i < eventos.Count() && !encontreEvento; i++)
            {
                if (eventos[i].Id == evento.Id)
                {
                    eventos[i] = evento;
                    encontreEvento = true;
                }
            }
           
            if (encontreEvento)
            {
                RemplazarEventos(eventos);
            }
            else
            {
                throw new EntidadNotFoundException("No se encontro el id correspondiente");

            }
        }
    }

    private void RemplazarEventos(List<EventoDeportivo> eventos)
    {
        using (StreamWriter sw = new StreamWriter(archivoEventos))
        {
            foreach (EventoDeportivo eve in eventos)
            {
                sw.WriteLine(eve.ToString());
            }
        }
    }
    
}
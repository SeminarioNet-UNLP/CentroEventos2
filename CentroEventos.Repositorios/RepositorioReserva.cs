using CentroEventos.Aplicaciones.Excepciones;

public class RepositorioReserva : IRepositorioReserva
{

    private const int CantPropsReserva = 6;
    private readonly string rutaIDs = "IdReserva.txt";

    private readonly string archivoReservas = "ReservasPersistencia.txt";

    public void AltaReserva(Reserva reserva)
    {
        string mensajeError = "";
        int ultimoId = IdManager.BuscarUltimoId(rutaIDs, out mensajeError);
        if (ultimoId >= 0)
        {
            reserva.Id = ultimoId + 1;
            try
            {
                using (StreamWriter sw = new StreamWriter(archivoReservas, true))
                {
                    sw.WriteLine(reserva.ToString());
                }
                IdManager.ActualizarArchivoId(rutaIDs, reserva.Id);
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

    // Ver si las bajas deberian ser un bool
    public void BajaReserva(int id)
    {
        if (id < 0)
        {
            throw new ValidacionException("No puede ser negativo el ID.");
        }
        try
        {
            var archivo = File.ReadAllLines(archivoReservas);
            var nuevoarchivo = new List<string>();
            bool encontre = false;
            foreach (var linea in archivo)
            {
                var partes = linea.Split(' ');
                if (int.Parse(partes[0]) == id)
                {
                    encontre = true;
                    continue;// Si encontre ID, no lo agrego al nuevo archivo
                }

                nuevoarchivo.Add(linea); // se agrega al nuevo archivo si no es la que quiero eliminar
            }
            if (!encontre)
                throw new Exception("No se encontro reserva con el ID.");
            File.WriteAllLines(archivoReservas, nuevoarchivo);// sobreescribo el archivo con las lineas restantes
        }
        catch (Exception e)
        {
            throw new Exception($"Error al eliminar la reserva: {e.Message}");
        }
    }



    public List<Reserva> ListadoReserva()
    {
        List<Reserva> listaReservas = new List<Reserva>();
        try
        {
            using (StreamReader sr = new StreamReader(archivoReservas))
            {
                string? lineaP;
                while (!sr.EndOfStream && (lineaP = sr.ReadLine()) != null)
                {
                    string[] campos = lineaP.Split(" ");
                    if (campos.Length == CantPropsReserva)
                    {
                        Reserva reserva = new Reserva(
                            int.Parse(campos[1]),
                            int.Parse(campos[2]),
                            DateTime.Parse(campos[3]),
                            Enum.Parse<EstadosAsistencia>(campos[4])
                        );
                        reserva.Id = int.Parse(campos[0]);
                        listaReservas.Add(reserva);
                    }
                }
            }
        }
        catch
        {
            return listaReservas;
        }
        return listaReservas;
    }



    public void ModificarReserva(Reserva reserva)
    {
        List<Reserva> listaReservas = ListadoReserva();
        bool cambie = false;
        if(listaReservas!=null)
        {
            for (int i = 0; i < listaReservas.Count() && !cambie; i++)
            {
            if (listaReservas[i].Id == reserva.Id)
            {
                listaReservas[i] = reserva;
                cambie = true;
            }
            }
            if(cambie)
            {
                RemplazarReservas(listaReservas);
            }
            else
            {
                throw new EntidadNotFoundException("ID no encontrado. No se puede modificar la reserva.");
            }
        }
        
    }
    private void RemplazarReservas(List<Reserva> reservas)
    {
        using (StreamWriter sw = new StreamWriter(archivoReservas))
        {
            foreach (Reserva res in reservas)
            {
                sw.WriteLine(res.ToString());
            }
        }
        
    }
}
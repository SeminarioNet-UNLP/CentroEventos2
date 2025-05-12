public static class IdManager
{
    public static int BuscarUltimoId(string ruta, out string mensajeError)
    {
        int aux = 0;
        mensajeError  = "";
        if(File.Exists(ruta))
        {
            using (StreamReader sr = new StreamReader(ruta))
            {
              while(!sr.EndOfStream)
              {
                 aux = sr.Read();
              }
            }
        }
        else
        {
          aux = -1;
          mensajeError = "no existe el archivo actual";
        }
        return aux;

    }
    public static void ActualizarArchivoId(string ruta, int id)
    {
      try
      {
        using (StreamWriter sw = new StreamWriter(ruta,true))
        {
          sw.WriteLine(id);
        }
      }
      catch (Exception e)
      {
        throw new Exception($"No se pudo guardar el id: {e.Message}");
      }  
    }
}
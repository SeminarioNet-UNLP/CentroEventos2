public static class BusquedaId
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
<<<<<<< HEAD
        return aux; //0 sino encuentra nada o esta vacio
=======
        else
        {
          aux = -1;
          mensajeError = "no existe el archivo actual";
        }
        return aux;
>>>>>>> ddb4737 (- Agrege cambios en la clase de utilidad)
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
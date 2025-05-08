public static class BusquedaId
{
    public static int BuscarUltimoId(string ruta)
    {
        int aux = 0;
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
        return aux;
    }
    public static void ActualziarArchivoid(string ruta, int id)
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
using Microsoft.EntityFrameworkCore;

public static class CentroEventosSQLite
{
    public static void Inicializar()
    {
        using var context = new CentroEventosContext();
        context.Database.EnsureCreated(); 
        var connection = context.Database.GetDbConnection(); 
        connection.Open(); 
        using (var command = connection.CreateCommand()) 
        { 
            command.CommandText = "PRAGMA journal_mode=DELETE;"; 
            command.ExecuteNonQuery(); 
        }
    }
}
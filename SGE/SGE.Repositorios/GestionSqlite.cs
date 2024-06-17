namespace SGE.Repositorios;

public class GestionSqlite
{
    public static void Inicializar()
    {
        using var context = new RepositorioContext();
        if (context.Database.EnsureCreated())
        {
            Console.WriteLine("Se creó base de datos");
        }
    }

}
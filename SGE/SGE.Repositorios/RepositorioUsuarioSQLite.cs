using SGE.Aplicacion;

namespace SGE.Repositorios;

public class RepositorioUsuarioSQLite : IUsuarioRepositorio
{
    public bool EmailRepetido(string email)
    {
        throw new NotImplementedException();
    }

    public void UsuarioAlta(string nombre, string apellido, string email, string password)
    {
        throw new NotImplementedException();
    }
    public void UsuarioBaja(string email)
    {
        throw new NotImplementedException();
    }

    public bool UsuarioInicioDeSesion(string email, string password)
    {
        throw new NotImplementedException();
    }

    public void UsuarioModicacionContraseña(string password)
    {
        throw new NotImplementedException();
    }

    public void UsuarioModicacionDatosPersonales(string nombre, string apellido, string email)
    {
        throw new NotImplementedException();
    }

    public void UsuarioModicacionPermisos(string email, List<string> permisos)
    {
        throw new NotImplementedException();
    }

    public void UsuarioModicacionUsuarioCompleto(string nombre, string apellido, string email, string password)
    {
        throw new NotImplementedException();
    }
}

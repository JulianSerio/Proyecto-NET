using SGE.Aplicacion;
using Microsoft.EntityFrameworkCore;

namespace SGE.Repositorios;

public class RepositorioUsuarioSQLite : IUsuarioRepositorio
{
    public RepositorioUsuarioSQLite(){
        using var context = new RepositorioContext();
        context.Database.EnsureCreated(); //si la base de datos no existe se crea y devuelve true
    }
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

    public List<Usuario> UsuarioBusquedaTodos()
    {
        throw new NotImplementedException();
    }


    public void UsuarioModicacion(Usuario user, List<string> permisos)
    {
        throw new NotImplementedException();
    }

    public bool UsuarioValidarPermiso(string permiso)
    {
        throw new NotImplementedException();
    }

    public Usuario UsuarioInicioDeSesion(string email, string password)
    {
        throw new NotImplementedException();
    }
}

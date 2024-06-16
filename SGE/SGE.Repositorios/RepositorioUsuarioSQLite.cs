using SGE.Aplicacion;
using Microsoft.EntityFrameworkCore;

namespace SGE.Repositorios;

public class RepositorioUsuarioSQLite : IUsuarioRepositorio
{
    public RepositorioUsuarioSQLite(){
        using var context = new RepositorioContext();
        context.Database.EnsureCreated(); //si la base de datos no existe se crea y devuelve true
    }
    public bool EmailRepetido(string? email)
    {
        throw new NotImplementedException();
    }

    public void UsuarioAlta(string nombre, string apellido, string email, string password){
        using var db = new RepositorioContext();
        var usuario = new Usuario(nombre,apellido, email, password);
        db.Add(usuario);//se agregará realmente con el db.SaveChanges()
        db.SaveChanges();//actualiza la base de datos. SQlite establece el valor de usuario.Id
        
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

    public Usuario UsuarioInicioDeSesion(string email, string password)
    {
        throw new NotImplementedException();
    }

    public bool UsuarioValidarPermiso(string permiso, int idUsuario)
    {
        throw new NotImplementedException();
    }
}

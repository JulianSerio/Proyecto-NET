using SGE.Aplicacion;
using Microsoft.EntityFrameworkCore;

namespace SGE.Repositorios;

public class RepositorioUsuarioSQLite : IUsuarioRepositorio
{
    public RepositorioUsuarioSQLite(){
        using (var context = new RepositorioContext()){
            context.Database.EnsureCreated(); //si la base de datos no existe se crea y devuelve true
            var connection = context.Database.GetDbConnection();
            connection.Open();
            using (var command = connection.CreateCommand()){
                command.CommandText = "PRAGMA journal_mode=DELETE;";
                command.ExecuteNonQuery();
            }
        }
    }
    public bool EmailRepetido(string? email){
        bool repetido=false;
        using (var db = new RepositorioContext()){
            var usuario = db.Usuarios.FirstOrDefault(u => u.Email == email); 
            if (usuario == null){
                repetido=true;
            }
            return repetido;
        }
    }

    public void UsuarioAlta(string nombre, string apellido, string email, string password){
        using (var db = new RepositorioContext()){
            var usuario = new Usuario(nombre,apellido, email, password);
            db.Add(usuario);//se agregará realmente con el db.SaveChanges()
            db.SaveChanges();//actualiza la base de datos. SQlite establece el valor de usuario.Id
            if(usuario.IdUsuario == 1){ //se obtiene el id
                List<string> permisos = new List<string>{"ExpedienteBaja","ExpedienteAlta","ExpedienteModificacion","TramiteAlta","TramiteBaja","TramiteModificacion"};
                this.UsuarioModicacion(usuario, permisos);
            }
        }
    }

    public void UsuarioBaja(string email){
        using (var db = new RepositorioContext()){
            var usuarioABorrar = db.Usuarios.FirstOrDefault(u => u.Email == email); 
            if (usuarioABorrar != null){
                db.Remove(usuarioABorrar); //se borra realmente con el db.SaveChanges()
                db.SaveChanges();//actualiza la base de datos. SQlite establece el valor de usuario.Id
            }else{
                throw new RepositorioException("El email ingresado no existe en el repositorio");    
            }
            
        }
    }

    public List<Usuario> UsuarioBusquedaTodos(){
        using (var db = new RepositorioContext()){
            var usuarios = db.Usuarios.ToList();
            if(usuarios.Count == 0){
                throw new RepositorioException("No existen usuarios en el sistema");
            }
            return usuarios;
        }
    }

    public void UsuarioModicacion(Usuario user, List<string> permisos){
        using(var db = new RepositorioContext()){
            var usuarioAModificar = db.Usuarios.FirstOrDefault(u => u.IdUsuario == user.IdUsuario);
            if(usuarioAModificar != null){
                usuarioAModificar.Nombre = user.Nombre;
                usuarioAModificar.Apellido = user.Apellido;
                usuarioAModificar.Email = user.Email;
                usuarioAModificar.Password = user.Password;
                usuarioAModificar.Permisos = permisos;

                db.SaveChanges();
            }else{
                throw new RepositorioException("El email ingresado no existe en el repositorio");
            }
        }
    }

    public Usuario UsuarioInicioDeSesion(string email, string password){ //si no lo encuentra envia una excepcion
        using(var db = new RepositorioContext()){
            var usuario = db.Usuarios.FirstOrDefault(u => u.Email == email);
            if(usuario != null){
                if (usuario.Password == password){
                    return usuario;
                }else{
                    throw new RepositorioException("La contraseña ingresada no corresponde con el email ingresado");
                }
            }
            else{
                throw new RepositorioException("El email ingresado no existe en el repositorio");
            }
        }
    }

    public bool UsuarioValidarPermiso(string permiso, int idUsuario){
        using(var db = new RepositorioContext()){
            var usuario = db.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario); //no puede enviar null, ya que es la id del usuario utilizando el sistema
            if(usuario != null){
                if(usuario.Permisos != null){
                    return usuario.Permisos.Contains(permiso);
                }else{
                    return false;
                }
            } 
            return false; //para emergencias 
        }
    }

    public Usuario BusquedaPorId(int idUsuario){
        using (var db = new RepositorioContext()){
            var usuario = db.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);
            if(usuario != null){
                return usuario;
            }else{
                throw new RepositorioException("El id ingresado no corresponde a un usuario registrado");
            }
        }
    }
}
using SGE.Aplicacion;
using Microsoft.EntityFrameworkCore;
namespace SGE.Repositorios;
public class RepositorioExpedienteSQLite : IExpedienteRepositorio
{
    public void ActualizarEstado(int idExpediente, EstadoExpediente.Estados? estado, DateTime fechaDeModificacion)
    {
        throw new NotImplementedException();
    }

    public void ExpedienteAlta(Expediente expediente, DateTime fecha)
    {
        using (var db = new RepositorioContext()){
            db.Add(expediente);//se agregará realmente con el db.SaveChanges()
            db.SaveChanges();//actualiza la base de datos. SQlite establece el valor de usuario.Id
        }
    }
    public void UsuarioAlta(string nombre, string apellido, string email, string password){
        using (var db = new RepositorioContext()){
            var usuario = new Usuario(nombre,apellido, email, password);
            db.Add(usuario);//se agregará realmente con el db.SaveChanges()
            db.SaveChanges();//actualiza la base de datos. SQlite establece el valor de usuario.Id
        }
    }

    public void ExpedienteBaja(int idExpediente)
    {
        throw new NotImplementedException();
    }

    public ConsultaExpediente ExpedienteBusquedaID(int idExpediente)
    {
        throw new NotImplementedException();
    }

    public List<Expediente> ExpedienteBusquedaTodos()
    {
        throw new NotImplementedException();
    }

    public void ExpedienteModificacion(int idExpediente, DateTime fechaModificacion, Expediente expediente)
    {
        throw new NotImplementedException();
    }
}

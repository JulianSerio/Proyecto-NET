using SGE.Aplicacion;
using Microsoft.EntityFrameworkCore;
namespace SGE.Repositorios;
public class RepositorioExpedienteSQLite : IExpedienteRepositorio
{
    public void ActualizarEstado(int idExpediente, EstadoExpediente.Estados estado, int idUsuario)
    {
        using (var db = new RepositorioContext()){
            var expedienteAActualizar = db.Expedientes.FirstOrDefault(e => e.Id == idExpediente);
            if (expedienteAActualizar != null){
                expedienteAActualizar.Estado = estado;
                expedienteAActualizar.FechaModificacion = DateTime.Now;
                expedienteAActualizar.IdUsuarioModificador = idUsuario;
                db.SaveChanges();
            }else{
                throw new RepositorioException();
            }
            
        }
    }

    public void ExpedienteAlta(String caratula, int idUsuario, DateTime fecha)
    {
        using (var db = new RepositorioContext()){
            var expediente = new Expediente(caratula,fecha,idUsuario);
            db.Add(expediente);//se agregará realmente con el db.SaveChanges()
            db.SaveChanges();//actualiza la base de datos. SQlite establece el valor de usuario.Id
        }
    }

    public void ExpedienteBaja(int idExpediente)
    {
        using (var db = new RepositorioContext()){
            var expedienteABorrar = db.Expedientes.FirstOrDefault(e => e.Id == idExpediente);
            if (expedienteABorrar != null){
                db.Remove(expedienteABorrar);//se borra realmente con el db.SaveChanges()
                db.SaveChanges();//actualiza la base de datos.
            }else{
                throw new RepositorioException();
            }
        }
    }

    public ConsultaExpediente ExpedienteBusquedaID(int idExpediente)
    {
        using (var db = new RepositorioContext()){
            var consultaExpediente = new ConsultaExpediente();
            consultaExpediente.Expediente = db.Expedientes.FirstOrDefault(e => e.Id == idExpediente);
            var repositorioTramite = new RepositorioTramiteSQLite();
            consultaExpediente.ListaTramites = repositorioTramite.BusquedaPorExpediente(idExpediente);
            return consultaExpediente;
        }
    }

    public List<Expediente> ExpedienteBusquedaTodos()
    {
        using (var db = new RepositorioContext()){
            var expedientes = db.Expedientes.ToList();
            if (expedientes.Count == 0){
                throw new RepositorioException();
            }
            return expedientes;
        }
    }

    public void ExpedienteModificacion(int idExpediente, Expediente expediente, int idUsuario)
    {
        using (var db = new RepositorioContext()){
            var expedienteAModificar = db.Expedientes.FirstOrDefault(e => e.Id == idExpediente);
            if(expedienteAModificar != null){
                expedienteAModificar = expediente;
                expedienteAModificar.FechaModificacion = DateTime.Today;
                expediente.IdUsuarioModificador = idUsuario;

                db.SaveChanges();
            }else{
                throw new RepositorioException();
            }
        }
    }
    
}

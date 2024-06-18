using SGE.Aplicacion;
namespace SGE.Repositorios;
using Microsoft.EntityFrameworkCore;
public class RepositorioExpedienteSQLite : IExpedienteRepositorio
{
    public void ActualizarEstado(int idExpediente, EstadoExpediente.Estados? estado, DateTime fechaModificacion, int idUsuario)
    {
        using (var db = new RepositorioContext()){
            var expedienteAActualizar = db.Expedientes.FirstOrDefault(e => e.Id == idExpediente);
            if (expedienteAActualizar != null){
                expedienteAActualizar.Estado = estado;
                expedienteAActualizar.FechaModificacion = fechaModificacion;
                expedienteAActualizar.IdUsuarioModificador = idUsuario;
                db.SaveChanges();
            }else{
                throw new RepositorioException(); //este trhow es imposible que se lance
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
                throw new RepositorioException("El id del expediente ingresado no existe en el repositorio");
            }
        }
    }

    public ConsultaExpediente ExpedienteBusquedaID(int idExpediente)
    {
        using (var db = new RepositorioContext()){
            var consultaExpediente = new ConsultaExpediente();
            consultaExpediente.Expediente = db.Expedientes.FirstOrDefault(e => e.Id == idExpediente);
            if(consultaExpediente.Expediente == null){
                throw new RepositorioException("El id del expediente ingresado no existe en el repositorio");
            }else{
                var repositorioTramite = new RepositorioTramiteSQLite();
                consultaExpediente.ListaTramites = repositorioTramite.BusquedaPorExpediente(idExpediente); //esto puede estar vacio en teoria
                return consultaExpediente;
            }
        }
    }

    public List<Expediente> ExpedienteBusquedaTodos()
    {
        using (var db = new RepositorioContext()){
            var expedientes = db.Expedientes.ToList();
            if (expedientes.Count == 0){
                throw new RepositorioException("No se encuentran Expedientes en el repositorio");
            }
            return expedientes;
        }
    }

    public void ExpedienteModificacion(int idExpediente, string caratula, DateTime fechaModificacion, int idUsuario)
    {
        using (var db = new RepositorioContext()){
            var expedienteAModificar = db.Expedientes.FirstOrDefault(e => e.Id == idExpediente);
            if(expedienteAModificar != null){
                expedienteAModificar.Caratula = caratula;
                expedienteAModificar.FechaModificacion = fechaModificacion;
                expedienteAModificar.IdUsuarioModificador = idUsuario;

                db.SaveChanges();
            }else{
                throw new RepositorioException("El id del expediente ingresado no existe en el repositorio");
            }
        }
    }
    
}

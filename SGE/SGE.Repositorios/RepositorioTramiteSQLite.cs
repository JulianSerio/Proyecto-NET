using SGE.Aplicacion;
using Microsoft.EntityFrameworkCore;
namespace SGE.Repositorios;

public class RepositorioTramiteSQLite : ITramiteRepositorio
{
    public List<Tramite>? BusquedaPorEtiqueta(EtiquetaTramite.Etiquetas etiqueta)
    {
        using (var db = new RepositorioContext()){
            var tramites = db.Tramites.Where(t => t.EtiquetaTramite == etiqueta).ToList();
            if(tramites.Count == 0){
                throw new RepositorioException("No se han encontrado tramites con esa etiqueta");
            }
            return tramites;
        }
    }
    public List<Tramite> BusquedaPorExpediente(int idExpediente)
    {
        using (var db = new RepositorioContext()){
            var tramites = db.Tramites.Where(t => t.ExpedienteId == idExpediente).ToList();
            /*if(tramites.Count == 0){
                throw new RepositorioException();
            }*/
            return tramites;
        }
    }

    public EtiquetaTramite.Etiquetas? EtiquetaUltimoTramiteDeExpediente(int idExpediente)
    {
        using (var db = new RepositorioContext()){
            var tramites = BusquedaPorExpediente(idExpediente);
            return tramites.Last().EtiquetaTramite;
        }
    }

    /*public void actualizarSegunUltimoTramite(int idExpediente, int idUsuario){
        var repositorioExpediente = new RepositorioExpedienteSQLite();
        switch (EtiquetaUltimoTramiteDeExpediente(idExpediente))
        {
        case EtiquetaTramite.Etiquetas.Resolucion:
            repositorioExpediente.ActualizarEstado(idExpediente,EstadoExpediente.Estados.ConResolucion,idUsuario);
            break;
        case EtiquetaTramite.Etiquetas.PaseAEstudio:
            repositorioExpediente.ActualizarEstado(idExpediente,EstadoExpediente.Estados.ParaResolver,idUsuario);
            break;
        case EtiquetaTramite.Etiquetas.PaseAlArchivo:
            repositorioExpediente.ActualizarEstado(idExpediente,EstadoExpediente.Estados.Finalizado,idUsuario);
            break;
        }
    }*/

    public void TramiteAlta(int expedienteID, string contenido, int idUsuario, EtiquetaTramite.Etiquetas etiqueta, DateTime fechaCreacio)
    {
        using (var db = new RepositorioContext()){
            var tramite = new Tramite(expedienteID, contenido, fechaCreacio, fechaCreacio, idUsuario, etiqueta);
            db.Add(tramite);//se agregará realmente con el db.SaveChanges()
            db.SaveChanges();//actualiza la base de datos. SQlite establece el valor de usuario.Id
           //actualizarSegunUltimoTramite(tramite.ExpedienteId,idUsuario);
        }
    }

    public int TramiteBaja(int idTramite){
        int idExpediente;
        using (var db = new RepositorioContext()){
            var tramiteABorrar = db.Tramites.FirstOrDefault(e => e.Id == idTramite);
            if (tramiteABorrar != null){
                idExpediente=tramiteABorrar.ExpedienteId;
                db.Remove(tramiteABorrar);//se borra realmente con el db.SaveChanges()
                db.SaveChanges();//actualiza la base de datos.
                //actualizarSegunUltimoTramite(tramiteABorrar.ExpedienteId,idUsuario);

                return idExpediente;
            }else{
                throw new RepositorioException("El id del tramite ingresado no existe en el repositorio");
            }
        }
    }
    
    /*
    ESTO TIRA ERROR 
    public void TramiteBajaPorExpediente(int idExpediente){
        using (var db = new RepositorioContext()){
            var tramitesABorrar = db.Tramites.Where(t => t.ExpedienteId == idExpediente).ToList;
            foreach(var tramite in tramitesABorrar){
                db.Remove(tramite);
            }
            if (tramitesABorrar.Count > 0){
                db.SaveChanges();
            }
        }
    }*/

    public int TramiteModificacion(int idTramite, string contenido, EtiquetaTramite.Etiquetas etiqueta, int idUsuario, DateTime fechaModificacion){
        using (var db = new RepositorioContext()){
            var tramiteAModificar = db.Tramites.FirstOrDefault(e => e.Id == idTramite);
            if(tramiteAModificar != null){
                tramiteAModificar.Contenido = contenido;
                tramiteAModificar.FechaModificacion = fechaModificacion;
                tramiteAModificar.EtiquetaTramite = etiqueta;
                tramiteAModificar.IdUsuarioModificador = idUsuario;

                db.SaveChanges();

                //actualizarSegunUltimoTramite(tramite.ExpedienteId,idUsuario);

                return tramiteAModificar.ExpedienteId;
            }else{
                throw new RepositorioException("El id del tramite ingresado no existe en el repositorio");
            }
        }
    }
}

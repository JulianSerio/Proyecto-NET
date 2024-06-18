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
                throw new RepositorioException();
            }
            return tramites;
        }
    }
    public List<Tramite> BusquedaPorExpediente(int idExpediente)
    {
        using (var db = new RepositorioContext()){
            var tramites = db.Tramites.Where(t => t.ExpedienteId == idExpediente).ToList();
            if(tramites.Count == 0){
                throw new RepositorioException();
            }
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

    public void actualizarSegunUltimoTramite(int idExpediente, int idUsuario){
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
    }

    public void TramiteAlta(int expedienteID, string contenido, int idUsuario, EtiquetaTramite.Etiquetas etiqueta)
    {
        using (var db = new RepositorioContext()){
            var tramite = new Tramite(expedienteID,contenido,DateTime.Now,DateTime.Now,idUsuario,etiqueta);
            db.Add(tramite);//se agregará realmente con el db.SaveChanges()
            db.SaveChanges();//actualiza la base de datos. SQlite establece el valor de usuario.Id
            actualizarSegunUltimoTramite(tramite.ExpedienteId,idUsuario);
        }
    }

    public void TramiteBaja(int idTramite, int idUsuario)
    {
        using (var db = new RepositorioContext()){
            var tramiteABorrar = db.Tramites.FirstOrDefault(e => e.Id == idTramite);
            if (tramiteABorrar != null){
                db.Remove(tramiteABorrar);//se borra realmente con el db.SaveChanges()
                db.SaveChanges();//actualiza la base de datos.
                actualizarSegunUltimoTramite(tramiteABorrar.ExpedienteId,idUsuario);
            }else{
                throw new RepositorioException();
            }
        }
    }

    public void TramiteModificacion(int idTramite, Tramite tramite, int idUsuario)
    {
        using (var db = new RepositorioContext()){
            var tramiteAModificar = db.Tramites.FirstOrDefault(e => e.Id == idTramite);
            if(tramiteAModificar != null){
                tramiteAModificar = tramite;
                tramiteAModificar.FechaModificacion = DateTime.Today;
                tramite.IdUsuarioModificador = idUsuario;

                db.SaveChanges();

                actualizarSegunUltimoTramite(tramite.ExpedienteId,idUsuario);
            }else{
                throw new RepositorioException();
            }
        }
    }
}

﻿using SGE.Aplicacion;
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
            return tramites;
        }
    }

    public EtiquetaTramite.Etiquetas? EtiquetaUltimoTramiteDeExpediente(int idExpediente){
        using (var db = new RepositorioContext()){
            var tramites = BusquedaPorExpediente(idExpediente);
            if (tramites.Any()){
                return tramites.Last().EtiquetaTramite;
            }
        }
        return null; // Devuelve null si no hay tramites
    }

    public void TramiteAlta(int expedienteID, string contenido, int idUsuario, EtiquetaTramite.Etiquetas etiqueta, DateTime fechaCreacio)
    {
        using (var db = new RepositorioContext()){
            var tramite = new Tramite(expedienteID, contenido, fechaCreacio, fechaCreacio, idUsuario, etiqueta);
            db.Add(tramite);//se agregará realmente con el db.SaveChanges()
            db.SaveChanges();//actualiza la base de datos. SQlite establece el valor de usuario.Id
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

                return idExpediente;
            }else{
                throw new RepositorioException("El id del tramite ingresado no existe en el repositorio");
            }
        }
    }

    public int TramiteModificacion(int idTramite, string contenido, EtiquetaTramite.Etiquetas etiqueta, int idUsuario, DateTime fechaModificacion){
        using (var db = new RepositorioContext()){
            var tramiteAModificar = db.Tramites.FirstOrDefault(e => e.Id == idTramite);
            if(tramiteAModificar != null){
                tramiteAModificar.Contenido = contenido;
                tramiteAModificar.FechaModificacion = fechaModificacion;
                tramiteAModificar.EtiquetaTramite = etiqueta;
                tramiteAModificar.IdUsuarioModificador = idUsuario;

                db.SaveChanges();

                return tramiteAModificar.ExpedienteId;
            }else{
                throw new RepositorioException("El id del tramite ingresado no existe en el repositorio");
            }
        }
    }

    public List<Tramite> BusquedaTodos(){
        using (var db = new RepositorioContext()){
            var tramites = db.Tramites.ToList();
            return tramites;
        }
    }
}

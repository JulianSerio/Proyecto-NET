namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repo,ServicioAutorizacion autorizacion, ServicioActualizacionEstado actualizacion)
{
    public void Ejecutar(int idTramite, string contenido, EtiquetaTramite.Etiquetas etiqueta, int idUsuario){
        string permiso = "TramiteModificacion";
        if (autorizacion.PoseeElPermiso(permiso, idUsuario)) {//Verifico si el usuario tiene permisos
            int idExpediente= repo.TramiteModificacion(idTramite, contenido, etiqueta, idUsuario, DateTime.Now);
            if(idExpediente != -1){
                actualizacion.ModificarExpediente(idExpediente, idUsuario, DateTime.Now);
            }
        }else{
            throw new AutorizacionException("No posee el permiso necesario para modificar un tramite");
        }
    }
}

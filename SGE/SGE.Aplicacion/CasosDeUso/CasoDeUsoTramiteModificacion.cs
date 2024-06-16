namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repo,ServicioAutorizacion autorizacion, ServicioActualizacionEstado actualizacion)
{
    public void Ejecutar(int idTramite, Tramite tramite, int idUsuario){
        string permiso = "TramiteModificacion";
        if (autorizacion.PoseeElPermiso(permiso, idUsuario)) {//Verifico si el usuario tiene permisos
            int idExpediente= repo.TramiteModificacion(idTramite, tramite, idUsuario, DateTime.Now);
            if(idExpediente != -1){
                actualizacion.ModificarExpediente(idExpediente);
            } 
        } 
    }
}

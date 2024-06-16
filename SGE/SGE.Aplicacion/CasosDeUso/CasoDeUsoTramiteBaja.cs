namespace SGE.Aplicacion;

public class CasoDeUsoTramiteBaja(ITramiteRepositorio repo,ServicioAutorizacion autorizacion, ServicioActualizacionEstado actualizacion)
{
    public void Ejecutar(int idTramite, int idUsuario){
        string permiso = "TramiteBaja";
        if (autorizacion.PoseeElPermiso(permiso, idUsuario)) {//Verifico si el usuario tiene permisos
            int idExpediente = repo.TramiteBaja(idTramite);
            if(idExpediente != -1){
                actualizacion.ModificarExpediente(idExpediente);
            }  
        }
    }
}

namespace SGE.Aplicacion;

public class CasoDeUsoTramiteBaja(ITramiteRepositorio repo,ServicioAutorizacionProvisorio autorizacion, ServicioActualizacionEstado actualizacion)
{
    public void Ejecutar(int idTramite, int idUsuario){
        if (autorizacion.PoseeElPermiso(idUsuario)) {//Verifico si el usuario tiene permisos
            int idExpediente = repo.TramiteBaja(idTramite);
            if(idExpediente != -1){
                actualizacion.ModificarExpediente(idExpediente);
            }  
        }
    }
}

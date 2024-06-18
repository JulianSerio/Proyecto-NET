namespace SGE.Aplicacion;

public class CasoDeUsoTramiteBaja(ITramiteRepositorio repo,ServicioAutorizacion autorizacion, ServicioActualizacionEstado actualizacion)
{
    public void Ejecutar(int idTramite, int idUsuario){
        string permiso = "TramiteBaja";
        if (autorizacion.PoseeElPermiso(permiso, idUsuario)) {//Verifico si el usuario tiene permisos
            int idExpediente = repo.TramiteBaja(idTramite);
            actualizacion.ModificarExpediente(idExpediente, idUsuario, DateTime.Now);
        }else{
            throw new AutorizacionException("No posee el permiso necesario para dar de baja un tramite");
        }
    }
}

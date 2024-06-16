namespace SGE.Aplicacion;

public class CasoDeUsoTramiteAlta(ITramiteRepositorio repo, ServicioAutorizacion autorizacion, ServicioActualizacionEstado actualizacion) {
    public void Ejecutar(int expedienteID, Tramite tramite, int idUsuario){
        string permiso = "TramiteAlta";
        if (autorizacion.PoseeElPermiso(permiso, idUsuario)) {//Verifico si el usuario tiene permisos
            repo.TramiteAlta(expedienteID,tramite,DateTime.Now,idUsuario);
            actualizacion.ModificarExpediente(expedienteID);  
        } 
    }
    
}

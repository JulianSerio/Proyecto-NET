namespace SGE.Aplicacion;

public class CasoDeUsoTramiteAlta(ITramiteRepositorio repo, ServicioAutorizacionProvisorio autorizacion, ServicioActualizacionEstado actualizacion) {
    public void Ejecutar(int expedienteID, EtiquetaTramite.Etiquetas etiqueta, string? contenido, int idUsuario){
        try
        {
            if (autorizacion.PoseeElPermiso(idUsuario)) {//Verifico si el usuario tiene permisos
                repo.TramiteAlta(expedienteID,etiqueta,contenido,DateTime.Now,idUsuario);
                actualizacion.ModificarExpediente(expedienteID);  
            } 
        }
        catch (ValidacionException){
        }
    }
    
}

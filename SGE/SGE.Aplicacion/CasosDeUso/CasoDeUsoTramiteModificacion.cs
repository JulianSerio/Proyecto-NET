namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repo,ServicioAutorizacionProvisorio autorizacion, ServicioActualizacionEstado actualizacion)
{
    public void Ejecutar(int idTramite, string? nuevoContenido, int idUsuario, EtiquetaTramite.Etiquetas etiqueta){
        if (autorizacion.PoseeElPermiso(idUsuario)) {//Verifico si el usuario tiene permisos
            int idExpediente= repo.TramiteModificacion(idTramite, nuevoContenido, idUsuario, etiqueta, DateTime.Now);
            if(idExpediente != -1){
                actualizacion.ModificarExpediente(idExpediente);
            } 
        } 
    }
}

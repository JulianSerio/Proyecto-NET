namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repo,ServicioAutorizacionProvisorio autorizacion, ServicioActualizacionEstado actualizacion)
{
    public void Ejecutar(int idTramite, string nuevoContenido, int idUsuario, EtiquetaTramite.Etiquetas etiqueta){
        try
        {
            if (autorizacion.PoseeElPermiso(idUsuario)) {//Verifico si el usuario tiene permisos
                repo.TramiteModificacion(idTramite, nuevoContenido, idUsuario, etiqueta, DateTime.Now);
                int idExpediente= repo.BuscarIdExpediente(idTramite);
                actualizacion.ModificarExpediente(idExpediente);
            } 
        }
        catch (RepositorioException){
        }
        
    }
}

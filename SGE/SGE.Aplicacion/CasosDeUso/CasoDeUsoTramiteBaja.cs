namespace SGE.Aplicacion;

public class CasoDeUsoTramiteBaja(ITramiteRepositorio repo,ServicioAutorizacionProvisorio autorizacion, ServicioActualizacionEstado actualizacion)
{
    public void Ejecutar(int id, int idUsuario){
        try
        {
            if (autorizacion.PoseeElPermiso(idUsuario)) {//Verifico si el usuario tiene permisos
                repo.TramiteBaja(id);
                int idExpediente= repo.BuscarIdExpediente(id);
                if(idExpediente != -1){
                    actualizacion.ModificarExpediente(idExpediente);
                }  
            } 
        }
        catch (RepositorioException){
        }
    }
}

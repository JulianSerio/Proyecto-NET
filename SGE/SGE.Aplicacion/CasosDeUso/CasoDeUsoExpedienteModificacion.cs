namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion (ServicioActualizacionEstado actualizacion, ServicioAutorizacionProvisorio autorizacion){
    public void Ejecutar(int idExpediente, int idUsuario){
        if (autorizacion.PoseeElPermiso(idUsuario)){
            actualizacion.ModificarExpediente(idExpediente,DateTime.Now);
        }
    }


}

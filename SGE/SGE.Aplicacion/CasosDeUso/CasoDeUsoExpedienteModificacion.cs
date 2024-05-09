namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion (ServicioAutorizacionProvisorio autorizacion, IExpedienteRepositorio repositorio){
    public void Ejecutar(int idExpediente, int idUsuario, string? caratula){
        if (autorizacion.PoseeElPermiso(idUsuario)){
           repositorio.ExpedienteModificacion(idExpediente, DateTime.Now, caratula, idUsuario);
        }
    }


}

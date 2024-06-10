namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion (ServicioAutorizacionProvisorio autorizacion, IExpedienteRepositorio repositorio){
    public void Ejecutar(int idExpediente, int idUsuario, string? caratula){
        if (autorizacion.PoseeElPermiso(idUsuario)){ //se verifica si el usuario posee permiso para realizar esta operacion
            ExpedienteValidador.validar(caratula, idUsuario); //si es valido no tira excepcion
            repositorio.ExpedienteModificacion(idExpediente, DateTime.Now, caratula, idUsuario); //envio los datos al repo, si no existe envia una excepcio
        }
    }


}

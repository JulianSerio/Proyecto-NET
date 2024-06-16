namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion (ServicioAutorizacion autorizacion, IExpedienteRepositorio repositorio){
    public void Ejecutar(int idExpediente, Expediente expediente, int idUsuario){
        string permiso = "ExpedienteModificacion";
        if (autorizacion.PoseeElPermiso(permiso, idUsuario)){ //se verifica si el usuario posee permiso para realizar esta operacion
            ExpedienteValidador.validar(expediente.Caratula); //si es valido no tira excepcion
            repositorio.ExpedienteModificacion(idExpediente, DateTime.Now, expediente); //envio los datos al repo, si no existe envia una excepcio
        }
    }
}

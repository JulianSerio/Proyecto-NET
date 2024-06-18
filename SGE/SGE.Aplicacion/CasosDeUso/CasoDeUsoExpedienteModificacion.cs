namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion (ServicioAutorizacion autorizacion, IExpedienteRepositorio repositorio){
    public void Ejecutar(int idExpediente, string caratula, int idUsuario){
        string permiso = "ExpedienteModificacion";
        if (autorizacion.PoseeElPermiso(permiso, idUsuario)){ //se verifica si el usuario posee permiso para realizar esta operacion
            ExpedienteValidador.validar(caratula); //si es valido no tira excepcion
            repositorio.ExpedienteModificacion(idExpediente, caratula, DateTime.Now, idUsuario); //envio los datos al repo, si no existe envia una excepcio
        }else{
            throw new AutorizacionException("No posee el permiso necesario para modificar un expediente");
        }
    }
}

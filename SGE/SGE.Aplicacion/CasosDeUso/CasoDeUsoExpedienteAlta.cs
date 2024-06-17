namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteAlta(IExpedienteRepositorio repo, ServicioAutorizacion servicio) {
    public void Ejecutar(Expediente expediente, int idUsuario){
        string permiso = "ExpedienteAlta";
        if(servicio.PoseeElPermiso(permiso, idUsuario)){ //Verifico si el usuario tiene permisos
            ExpedienteValidador.validar(expediente.Caratula); //si es valido no tira excepcion
            repo.ExpedienteAlta(expediente,DateTime.Now); //envio los datos al repo
        }
    }
}
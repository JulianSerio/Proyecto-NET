namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteAlta(IExpedienteRepositorio repo, ServicioAutorizacion servicio) {
    public void Ejecutar(string caratula, int idUsuario){
        string permiso = "ExpedienteAlta";
        if(servicio.PoseeElPermiso(permiso, idUsuario)){ //Verifico si el usuario tiene permisos
            ExpedienteValidador.validar(caratula); //si es valido no tira excepcion
            repo.ExpedienteAlta(caratula, idUsuario, DateTime.Now); //envio los datos al repo
        }else{
            throw new AutorizacionException("No posee el permiso necesario para crear un expediente");
        }
    }
}
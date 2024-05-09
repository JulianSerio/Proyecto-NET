namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteAlta(IExpedienteRepositorio repo,ServicioAutorizacionProvisorio servicio) {
    public void Ejecutar(string? caratula, int idUsuario){
        if (servicio.PoseeElPermiso(idUsuario)) { //Verifico si el usuario tiene permisos
            repo.ExpedienteAlta(caratula,DateTime.Now,idUsuario); //envio los datos al repo
        } 
    }
}

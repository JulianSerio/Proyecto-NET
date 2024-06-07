namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteAlta(IExpedienteRepositorio repo,ServicioAutorizacionProvisorio servicio) {
    public void Ejecutar(string? caratula, int idUsuario){
        if(servicio.PoseeElPermiso(idUsuario)){ //Verifico si el usuario tiene permisos
            try
            {
                ExpedienteValidador.validar(caratula, idUsuario); //si es valido no tira excepcion
                repo.ExpedienteAlta(caratula,DateTime.Now,idUsuario); //envio los datos al repo
            }
            catch (ValidacionException ex)
            {
                Console.WriteLine(ex.Message); //imprime el mensaje de la excepcion
            }
        } 
    }
}

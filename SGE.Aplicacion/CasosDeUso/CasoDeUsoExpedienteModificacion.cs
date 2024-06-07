namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion (ServicioAutorizacionProvisorio autorizacion, IExpedienteRepositorio repositorio){
    public void Ejecutar(int idExpediente, int idUsuario, string? caratula){
        if (autorizacion.PoseeElPermiso(idUsuario)){ //se verifica si el usuario posee permiso para realizar esta operacion
            try
            {
                ExpedienteValidador.validar(caratula, idUsuario); //si es valido no tira excepcion
                try
                {
                    repositorio.ExpedienteModificacion(idExpediente, DateTime.Now, caratula, idUsuario); //envio los datos al repo, si no existe envia una excepcion
                }
                catch (RepositorioException ex)
                {
                    Console.WriteLine(ex.Message); //imprime el mensaje de la excepcion de repositorio
                }
            }
            catch (ValidacionException ex)
            {
                Console.WriteLine(ex.Message); //imprime el mensaje de la excepcion de validacion
            }
        }
    }


}

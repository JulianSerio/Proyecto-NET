using System.Data.Common;

namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja (IExpedienteRepositorio repositorio,ServicioAutorizacionProvisorio servicio){
    public void Ejecutar (int idExpediente, int idUsuario){
        if (servicio.PoseeElPermiso(idUsuario)) {//Verifico si el usuario tiene permisos
            try
            {
                repositorio.ExpedienteBaja(idExpediente); //envio los datos al repo y este envia una excepcion si no lo encuentra
            }
            catch (RepositorioException ex)
            {
                Console.WriteLine(ex.Message); //imprime el mensaje de la excepcion de repositorio
            }
        } 
    }

}

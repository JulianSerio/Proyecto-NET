using System.Data.Common;

namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja (IExpedienteRepositorio repositorio,ServicioAutorizacion servicio){
    public void Ejecutar (int idExpediente, int idUsuario){
        string permiso = "ExpedienteBaja";
        if (servicio.PoseeElPermiso(permiso, idUsuario)) {//Verifico si el usuario tiene permisos
            repositorio.ExpedienteBaja(idExpediente); //envio los datos al repo y este envia una excepcion si no lo encuentra
        }else{
            throw new AutorizacionException("No posee el permiso necesario para borrar un expediente");
        }
    }

}

using System.Data.Common;

namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja (IExpedienteRepositorio repositorio,ServicioAutorizacionProvisorio servicio){
    public void Ejecutar (int idExpediente, int idUsuario){
        if (servicio.PoseeElPermiso(idUsuario)) {//Verifico si el usuario tiene permisos
            repositorio.ExpedienteBaja(idExpediente);
        } 
    }

}

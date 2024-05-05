namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaPorId(IExpedienteRepositorio repositorio){
    public ConsultaExpediente Ejecutar (int idExpediente){
        return repositorio.ExpedienteBusquedaID(idExpediente);
    }

}

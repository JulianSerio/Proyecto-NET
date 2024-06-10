namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaPorId(IExpedienteRepositorio repositorio){
    public ConsultaExpediente Ejecutar (int idExpediente){
        ConsultaExpediente consulta = new ConsultaExpediente();
        consulta = repositorio.ExpedienteBusquedaID(idExpediente); //envio al repo la id y este me devuelve una ConsultaExpediente
        return consulta;
    }
}

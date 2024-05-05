namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaTodos(IExpedienteRepositorio repositorio) {
    public List<Expediente> Ejecutar(){
        return repositorio.ExpedienteBusquedaTodos();
    }    

}

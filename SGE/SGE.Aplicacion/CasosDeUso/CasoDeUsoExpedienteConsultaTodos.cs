namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaTodos(IExpedienteRepositorio repositorio) {
    public List<Expediente> Ejecutar(){
        return repositorio.ExpedienteBusquedaTodos(); //se solicita la lista de todos los expedientes y se devuelve
    }    

}

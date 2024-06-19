namespace SGE.Aplicacion;

public class CasoDeUsoTramiteConsultaTodos(ITramiteRepositorio repo){
    public List<Tramite> Ejecutar(){
        return repo.BusquedaTodos();
    }
}

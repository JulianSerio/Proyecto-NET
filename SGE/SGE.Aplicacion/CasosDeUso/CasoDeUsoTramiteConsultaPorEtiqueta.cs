namespace SGE.Aplicacion;

public class CasoDeUsoTramiteConsultaPorEtiqueta(ITramiteRepositorio repo)
{
    public List<Tramite>? Ejecutar (EtiquetaTramite.Etiquetas etiqueta){
        return repo.BusquedaPorEtiqueta(etiqueta);
    }
}

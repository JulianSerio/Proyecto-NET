namespace SGE.Aplicacion;

public interface ITramiteRepositorio
{
    void TramiteAlta(string? caratula, DateTime fecha, int idUsuarioModificador);
    void TramiteBaja(int idTramite);
    
    //ConsultaTramite TramiteBusquedaEtiqueta(String etiquetaTramite);  //esto devuelve una lista, no hace falta hacer una clase al pedo

    List<Tramite> TramiteBusquedaTodos();

    void TramiteModificacion(Tramite tramite);

    EtiquetaTramite.Etiquetas EtiquetaUltimoTramiteDeExpediente(int idExpediente);
}

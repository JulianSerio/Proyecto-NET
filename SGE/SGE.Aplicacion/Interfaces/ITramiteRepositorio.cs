namespace SGE.Aplicacion;

public interface ITramiteRepositorio
{
    void TramiteAlta(string? caratula, DateTime fecha, int idUsuarioModificador);
    void TramiteBaja(int idTramite);
    
    ConsultaTramite TramiteBusquedaEtiqueta(String etiquetaTramite);

    List<Tramite> TramiteBusquedaTodos();

    void TramiteModificacion(Tramite tramite);
}

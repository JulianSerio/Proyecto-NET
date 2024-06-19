namespace SGE.Aplicacion;

public interface ITramiteRepositorio
{
    void TramiteAlta(int expedienteID, string contenido, int idUsuario, EtiquetaTramite.Etiquetas etiqueta, DateTime fechaCreacion);
    int TramiteBaja(int idTramite);
    List<Tramite>? BusquedaPorEtiqueta(EtiquetaTramite.Etiquetas etiqueta);
    int TramiteModificacion(int idTramite, string contenido, EtiquetaTramite.Etiquetas etiqueta, int idUsuario, DateTime fechaModificacion);
    EtiquetaTramite.Etiquetas? EtiquetaUltimoTramiteDeExpediente(int idExpediente);
    List<Tramite> BusquedaTodos();
}

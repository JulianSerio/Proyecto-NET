namespace SGE.Aplicacion;

public interface ITramiteRepositorio
{
    void TramiteAlta(int id, int expedienteID, string contenido, int idUsuario, EtiquetaTramite.Etiquetas etiqueta);
    void TramiteBaja(int idTramite, int idUsuario);
    List<Tramite>? BusquedaPorEtiqueta(EtiquetaTramite.Etiquetas etiqueta);
    void TramiteModificacion(int idTramite, Tramite tramite, int idUsuario);
    EtiquetaTramite.Etiquetas? EtiquetaUltimoTramiteDeExpediente(int idExpediente);
}

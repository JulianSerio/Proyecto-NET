namespace SGE.Aplicacion;

public interface ITramiteRepositorio
{
    void TramiteAlta(int expedienteID, EtiquetaTramite.Etiquetas etiqueta, String? contenido, DateTime creacion, int idUsuario);
    void TramiteBaja(int idTramite);
    List<Tramite>? BusquedaPorEtiqueta(EtiquetaTramite.Etiquetas etiqueta);
    void TramiteModificacion(int idTramite, string nuevoContenido, int idUsuario, EtiquetaTramite.Etiquetas etiqueta, DateTime fechaDeModificacion);
    EtiquetaTramite.Etiquetas? EtiquetaUltimoTramiteDeExpediente(int idExpediente);
    int BuscarIdExpediente(int idTramite);
}

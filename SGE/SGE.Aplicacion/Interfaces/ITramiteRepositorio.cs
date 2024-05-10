namespace SGE.Aplicacion;

public interface ITramiteRepositorio
{
    void TramiteAlta(int expedienteID, EtiquetaTramite.Etiquetas etiqueta, String? contenido, DateTime creacion, int idUsuario);
    void TramiteBaja(int idTramite);
    List<Tramite>? TramiteBusquedaTodos();
    void TramiteModificacion(Tramite tramite, string nuevoContenido, int idUsuario, EtiquetaTramite.Etiquetas etiqueta);
    EtiquetaTramite.Etiquetas? EtiquetaUltimoTramiteDeExpediente(int idExpediente);
    void ActualizarEtiqueta(int idTramite, EtiquetaTramite.Etiquetas etiqueta);
}

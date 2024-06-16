namespace SGE.Aplicacion;

public interface ITramiteRepositorio
{
    void TramiteAlta(int expedienteID, Tramite tramite, DateTime creacion, int idUsuario);
    int TramiteBaja(int idTramite);
    List<Tramite>? BusquedaPorEtiqueta(EtiquetaTramite.Etiquetas etiqueta);
    int TramiteModificacion(int idTramite, Tramite tramite, int idUsuario, DateTime fechaDeModificacion);
    EtiquetaTramite.Etiquetas? EtiquetaUltimoTramiteDeExpediente(int idExpediente);
}

using SGE.Aplicacion;

namespace SGE.Repositorios;

public class RepositorioTramiteSQLite : ITramiteRepositorio
{
    public List<Tramite>? BusquedaPorEtiqueta(EtiquetaTramite.Etiquetas etiqueta)
    {
        throw new NotImplementedException();
    }

    public EtiquetaTramite.Etiquetas? EtiquetaUltimoTramiteDeExpediente(int idExpediente)
    {
        throw new NotImplementedException();
    }

    public void TramiteAlta(int expedienteID, EtiquetaTramite.Etiquetas etiqueta, string? contenido, DateTime creacion, int idUsuario)
    {
        throw new NotImplementedException();
    }

    public int TramiteBaja(int idTramite)
    {
        throw new NotImplementedException();
    }

    public int TramiteModificacion(int idTramite, string? nuevoContenido, int idUsuario, EtiquetaTramite.Etiquetas etiqueta, DateTime fechaDeModificacion)
    {
        throw new NotImplementedException();
    }
}

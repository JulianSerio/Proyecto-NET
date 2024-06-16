using SGE.Aplicacion;
using Microsoft.EntityFrameworkCore;
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

    public void TramiteAlta(int expedienteID, Tramite tramite, DateTime creacion, int idUsuario)
    {
        throw new NotImplementedException();
    }

    public int TramiteBaja(int idTramite)
    {
        throw new NotImplementedException();
    }

    public int TramiteModificacion(int idTramite, Tramite tramite, int idUsuario, DateTime fechaDeModificacion)
    {
        throw new NotImplementedException();
    }
}

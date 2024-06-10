using SGE.Aplicacion;

namespace SGE.Repositorios;
public class RepositorioExpedienteSQLite : IExpedienteRepositorio
{
    public void ActualizarEstado(int idExpediente, EstadoExpediente.Estados? estado, DateTime fechaDeModificacion)
    {
        throw new NotImplementedException();
    }

    public void ExpedienteAlta(string? caratula, DateTime fecha, int idUsuarioModificador)
    {
        throw new NotImplementedException();
    }

    public void ExpedienteBaja(int idExpediente)
    {
        throw new NotImplementedException();
    }

    public ConsultaExpediente ExpedienteBusquedaID(int idExpediente)
    {
        throw new NotImplementedException();
    }

    public List<Expediente> ExpedienteBusquedaTodos()
    {
        throw new NotImplementedException();
    }

    public void ExpedienteModificacion(int idExpediente, DateTime fechaModificacion, string? caratula, int idUsuario)
    {
        throw new NotImplementedException();
    }
}

namespace SGE.Aplicacion;


public interface IExpedienteRepositorio{
    void ExpedienteAlta(string? caratula, DateTime fecha, int idUsuarioModificador);
    void ExpedienteBaja(int idExpediente);
    
    ConsultaExpediente ExpedienteBusquedaID(int idExpediente);

    List<Expediente> ExpedienteBusquedaTodos();

    void ExpedienteModificacion(int idExpediente, DateTime fechaModificacion, string? caratula, int idUsuario);
    void ActualziarEstado(int idExpediente, EstadoExpediente.Estados? estado);
}

namespace SGE.Aplicacion;


public interface IExpedienteRepositorio{
    void ExpedienteAlta(string caratula, int idUsuario, DateTime fecha);
    void ExpedienteBaja(int idExpediente);
    ConsultaExpediente ExpedienteBusquedaID(int idExpediente);
    List<Expediente> ExpedienteBusquedaTodos();
    void ExpedienteModificacion(int idExpediente, Expediente expediente, int idUsuario);
    void ActualizarEstado(int idExpediente, EstadoExpediente.Estados estado, int idUsuario);
}

namespace SGE.Aplicacion;


public interface IExpedienteRepositorio{
    void ExpedienteAlta(Expediente expediente, DateTime fecha);
    void ExpedienteBaja(int idExpediente);
    ConsultaExpediente ExpedienteBusquedaID(int idExpediente);
    List<Expediente> ExpedienteBusquedaTodos();
    void ExpedienteModificacion(int idExpediente, DateTime fechaModificacion, Expediente expediente);
    void ActualizarEstado(int idExpediente, EstadoExpediente.Estados? estado, DateTime fechaDeModificacion);
}

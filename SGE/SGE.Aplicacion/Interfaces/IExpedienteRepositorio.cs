namespace SGE.Aplicacion;


public interface IExpedienteRepositorio{
    void ExpedienteAlta(string caratula, int idUsuario, DateTime fechaCreacion);
    void ExpedienteBaja(int idExpediente);
    ConsultaExpediente ExpedienteBusquedaID(int idExpediente);
    List<Expediente> ExpedienteBusquedaTodos();
    void ExpedienteModificacion(int idExpediente, string caratula, DateTime fechaModificacion, int idusuario);
    void ActualizarEstado(int idExpediente, EstadoExpediente.Estados? estado, DateTime fechaModificacion, int idUsuario);
}

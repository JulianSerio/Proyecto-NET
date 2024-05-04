namespace SGE.Aplicacion;


public interface IExpedienteRepositorio
{
    void ExpedienteAlta(Expediente expediente, int idUsuario);
    void ExpedienteBaja(Expediente expediente);
    
    //consultaporid
    //consultaportodos

    void ExpedienteModificacion(Expediente expediente);
}

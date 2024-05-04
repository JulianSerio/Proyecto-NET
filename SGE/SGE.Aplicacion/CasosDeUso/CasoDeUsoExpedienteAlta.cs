namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteAlta(IExpedienteRepositorio repo)
{
    public void Ejecutar(Expediente expediente, int idUsuario)
    {
        repo.ExpedienteAlta(expediente, idUsuario);
    }
}

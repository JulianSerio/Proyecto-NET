namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaPorId(IExpedienteRepositorio repositorio){
    public ConsultaExpediente Ejecutar (int idExpediente){
        ConsultaExpediente consulta = new ConsultaExpediente();
        try
        {
            consulta = repositorio.ExpedienteBusquedaID(idExpediente); //envio al repo la id y este me devuelve una ConsultaExpediente
            return consulta;
        }
        catch (RepositorioException ex)
        {
            Console.WriteLine(ex.Message); //imprime el mensaje de la excepcion de repositorio
            return consulta;
        }
    }
}

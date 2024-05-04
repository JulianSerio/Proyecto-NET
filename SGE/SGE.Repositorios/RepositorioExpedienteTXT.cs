namespace SGE.Repositorios;
using SGE.Aplicacion;

public class RepositorioExpedienteTXT
{
    readonly string _nameArch = "expedientes.txt";
    public void ExpedienteAlta(Expediente expediente, int idUsuario)
    {
        try
        {
            if(ExpedienteValidador.validar(expediente.Caratula, idUsuario)){
                using var sw = new StreamWriter(_nameArch, true);
            }
            else{
                throw new ValidacionException();
            }
        }
        catch (ValidacionException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

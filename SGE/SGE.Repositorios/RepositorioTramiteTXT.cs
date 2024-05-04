namespace SGE.Repositorios;
using SGE.Aplicacion;
public class RepositorioTramiteTXT
{
    readonly string _nameArch = "tramites.txt";
    public void TramiteAlta(Tramite tramite, int idUsuario)
    {
        try
        {
            if(TramiteValidador.validar(tramite.Contenido, idUsuario)){
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

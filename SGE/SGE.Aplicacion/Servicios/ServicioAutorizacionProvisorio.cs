
namespace SGE.Aplicacion;

public class ServicioAutorizacionProvisorio : IServicioAutorizacion
{
    public bool PoseeElPermiso(int idUsuario) { //recibe el id del expediente, en la version completa tiene que recibir el permiso del usuario
        try
        {
            if (idUsuario == 1) return true; //si id es 1 se asume que el usuario tiene permisos
            else throw new AutorizacionException(); //sino envia una excepcion
        }
        catch (AutorizacionException ex)
        {
            Console.WriteLine(ex.Message); //imprime el mensaje de la excepcion
            return false;
        }
    }
}

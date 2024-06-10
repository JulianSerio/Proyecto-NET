
namespace SGE.Aplicacion;

public class ServicioAutorizacionProvisorio : IServicioAutorizacion
{
    public bool PoseeElPermiso(int idUsuario) { //recibe el id del expediente, en la version completa tiene que recibir el permiso del usuario
        if (idUsuario == 1) return true; //si id es 1 se asume que el usuario tiene permisos
        else return false; //sino envia una excepcion
    }
}

namespace SGE.Aplicacion;

public class ServicioAutorizacionProvisorio : IServicioAutorizacion
{
    public bool PoseeElPermiso(int idUsuario, Permiso permiso) {
        try
        {
            if (idUsuario == 1) return true;
            else throw new AutorizacionException();
        }
        catch (AutorizacionException ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

}

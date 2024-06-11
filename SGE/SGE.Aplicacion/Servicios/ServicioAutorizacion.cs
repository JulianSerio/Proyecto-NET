namespace SGE.Aplicacion;

public class ServicioAutorizacion : IServicioAutorizacion
{
    public bool PoseeElPermiso(int IdUsuario){
        throw new NotImplementedException();
    }

    public bool EsAdmin(int idUsuario){
        return idUsuario == 1; //si es 1 devuelve true
    }
}

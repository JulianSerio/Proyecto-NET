namespace SGE.Aplicacion;

public class ServicioAutorizacion(IUsuarioRepositorio repo) : IServicioAutorizacion
{
    public bool PoseeElPermiso(string permiso, int idUsuario){
        return repo.UsuarioValidarPermiso(permiso, idUsuario); //si el usuario posee X permiso devuelve true, sino false
    }

    public bool EsAdmin(int? idUsuario){
        return idUsuario == 1; //si es 1 devuelve true
    }
}

namespace SGE.Aplicacion;

public interface IServicioAutorizacion {
    bool PoseeElPermiso(Permiso.Permisos permiso, int idUsuario);

    bool EsAdmin(int? idUsuario);
}

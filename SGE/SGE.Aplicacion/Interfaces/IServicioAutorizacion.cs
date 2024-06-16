namespace SGE.Aplicacion;

public interface IServicioAutorizacion {
    bool PoseeElPermiso(string permiso, int idUsuario);

    bool EsAdmin(int idUsuario);
}

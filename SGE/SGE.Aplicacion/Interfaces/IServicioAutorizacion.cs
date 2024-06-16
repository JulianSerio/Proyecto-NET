namespace SGE.Aplicacion;

public interface IServicioAutorizacion {
    bool PoseeElPermiso(string permiso);

    bool EsAdmin(int idUsuario);
}

namespace SGE.Aplicacion;

public interface IUsuarioRepositorio{
    void UsuarioAlta();
    void UsuarioBaja();
    void UsuarioModicacionPermisos();
    void UsuarioModicacionDatosPersonales();
    void UsuarioModicacionContraseña();
}

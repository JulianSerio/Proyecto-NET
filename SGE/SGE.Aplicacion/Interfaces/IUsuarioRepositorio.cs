namespace SGE.Aplicacion;

public interface IUsuarioRepositorio{
    void UsuarioAlta(string nombre, string apellido, string email, string password);
    void UsuarioBaja(string email);
    bool UsuarioInicioDeSesion(string email, string password); //devuelve true si es ADMIN, sino false. Si el usuario no existe se lanza una excepcion
    void UsuarioModicacionPermisos(string email, List<string> permisos);
    void UsuarioModicacionDatosPersonales(string nombre, string apellido, string email);
    void UsuarioModicacionContraseña(string password);
    void UsuarioModicacionUsuarioCompleto(string nombre, string apellido, string email, string password);
    bool EmailRepetido(string email);
}

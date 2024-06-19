namespace SGE.Aplicacion;

public interface IUsuarioRepositorio{
    void UsuarioAlta(string nombre, string apellido, string email, string password);
    void UsuarioBaja(string email);
    Usuario UsuarioInicioDeSesion(string email, string password); //devuelve true si es ADMIN, sino false. Si el usuario no existe se lanza una excepcion
    void UsuarioModicacion(Usuario user, List<string> permisos);
    bool EmailRepetido(string? email);
    List<Usuario> UsuarioBusquedaTodos();
    bool UsuarioValidarPermiso(string permiso, int idUsuario);
    Usuario BusquedaPorId(int idUsuario);
}

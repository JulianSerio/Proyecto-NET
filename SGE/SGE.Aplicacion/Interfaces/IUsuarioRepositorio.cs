namespace SGE.Aplicacion;

public interface IUsuarioRepositorio{
    int? UsuarioAlta(string nombre, string apellido, string email, string password);
    void UsuarioBaja(string email);
    Usuario UsuarioInicioDeSesion(string email, string password); //devuelve true si es ADMIN, sino false. Si el usuario no existe se lanza una excepcion
    void UsuarioModicacion(int? idUsuario,string nombre, string apellido, string email, string password, List<Permiso.Permisos>? permisos);
    bool EmailRepetido(string? email);
    List<Usuario> UsuarioBusquedaTodos();
    bool UsuarioValidarPermiso(Permiso.Permisos permiso, int idUsuario);
    Usuario BusquedaPorId(int idUsuario);
    List<Permiso.Permisos>? BusquedaPermisos(int idUsuario);
}

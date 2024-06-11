namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioIniciarSesion(IUsuarioRepositorio repo){
    public bool Ejecutar(string email, string password){ //en caso de que el usuario sea admin devuelve true, sino devuelvo false
        string passwordPasadaPorHash = ServicioFuncionHash.FuncionHashSHA256(password); //se vuelve a pasar por hash la contraseña para verificar si es igual al hash almacenado
        return repo.UsuarioInicioDeSesion(email, passwordPasadaPorHash); //si el usuario o contraseña no es correcto envia un repositorioExcepcion
    }
}

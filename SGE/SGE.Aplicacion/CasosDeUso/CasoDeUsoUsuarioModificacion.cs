namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioModificacion(IUsuarioRepositorio repo){
    public void Ejecutar(string email, List<string> permisos){ //modificar permisos //no hace falta validar porque esta opcion sola la puede ver el ADMIN
        repo.UsuarioModicacionPermisos(email, permisos); //se busca al usuario en base a su email, si no existe se lanza una excepcion
    }
    public void Ejecutar(string nombre, string apellido, string email){ //modificar datos personales
        var validador = new UsuarioValidador(repo); //no creo que este bien del todo CONSULTAR
        if(validador.Validar(email)){ //valida que el Email no exista en el repositorio
            repo.UsuarioModicacionDatosPersonales(nombre, apellido, email);
        }
    }
    public void Ejecutar(string password){ //modificar contraseña
        string passwordPasadaPorHash = ServicioFuncionHash.FuncionHashSHA256(password); //se pasa por la funcion Hash a la contraseña
        repo.UsuarioModicacionContraseña(passwordPasadaPorHash);
    }
    public void Ejecutar(string nombre, string apellido, string email, string password){//modificar todos los datos de un usuario
        var validador = new UsuarioValidador(repo); //no creo que este bien del todo CONSULTAR
        if(validador.Validar(email)){ //valida que el Email no exista en el repositorio
            string passwordPasadaPorHash = ServicioFuncionHash.FuncionHashSHA256(password);
            repo.UsuarioModicacionUsuarioCompleto(nombre, apellido, email, passwordPasadaPorHash);
        }
    }
}

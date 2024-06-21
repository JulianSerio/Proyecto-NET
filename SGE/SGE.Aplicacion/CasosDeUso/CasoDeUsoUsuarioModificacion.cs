namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioModificacion(IUsuarioRepositorio repo, UsuarioValidador validador){
    public void Ejecutar(int IdUsuario,string nombre, string apellido, string email, string password, List<Permiso.Permisos> permisos){ //modificar permisos
        if(validador.Validar(email!)){ //el ! es para asegurarle al compilador de que email nunca puede ser null
            repo.UsuarioModicacion(IdUsuario, nombre, apellido, email, password, permisos);
        }else{
            throw new ValidacionException("El email ingresado ya se encuentra registrado en la base de datos");
        }
    }
}

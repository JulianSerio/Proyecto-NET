namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioModificacion(IUsuarioRepositorio repo, UsuarioValidador validador){
    public void Ejecutar(Usuario user, List<string> permisos){ //modificar permisos //no hace falta validar porque esta opcion sola la puede ver el ADMIN
        if(validador.Validar(user.Email!)){ //el ! es para asegurarle al compilador de que email nunca puede ser null
            repo.UsuarioModicacion(user, permisos);
        }else{
            throw new ValidacionException("El email ingresado ya se encuentra registrado en la base de datos");
        }
    }
}

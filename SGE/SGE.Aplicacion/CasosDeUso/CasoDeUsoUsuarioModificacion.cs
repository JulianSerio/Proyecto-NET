namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioModificacion(IUsuarioRepositorio repo, UsuarioValidador validador){
    public void Ejecutar(Usuario user, List<string> permisos){ //modificar permisos //no hace falta validar porque esta opcion sola la puede ver el ADMIN
        if(validador.Validar(user.Email)){
            repo.UsuarioModicacion(user, permisos);
        }
    }
}

namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioBaja(IUsuarioRepositorio repo){
    public void Ejecutar(string email){ //no hace falta validar porque esta opcion sola la puede ver el ADMIN
        repo.UsuarioBaja(email); //si no existe el email en el repo tira RepositorioExcepcion
    }
}

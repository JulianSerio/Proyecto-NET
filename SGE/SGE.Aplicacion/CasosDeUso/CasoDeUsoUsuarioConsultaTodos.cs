namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioConsultaTodos(IUsuarioRepositorio repo){
    public List<Usuario> Ejecutar(){
        return repo.UsuarioBusquedaTodos();
    }
}

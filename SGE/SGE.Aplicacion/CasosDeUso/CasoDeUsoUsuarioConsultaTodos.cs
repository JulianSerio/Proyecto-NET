namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioConsultaTodos(IUsuarioRepositorio repo){
    public void Ejecutar(){
        repo.UsuarioBusquedaTodos();
    }
}

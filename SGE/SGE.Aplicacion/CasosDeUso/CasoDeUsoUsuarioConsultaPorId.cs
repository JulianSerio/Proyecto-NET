namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioConsultaPorId(IUsuarioRepositorio repo){
    public Usuario Ejecutar(int idUsuario){
        return repo.BusquedaPorId(idUsuario); //busca a un usuario mediante su id y lo devuelve
    }
}

namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioConsultaPermisos(IUsuarioRepositorio repo){
    public List<string> Ejecutar(int idUsuario){
        return repo.BusquedaPermisos(idUsuario)?.Select(p => p.ToString()).ToList() ?? new List<string>();
    }
}

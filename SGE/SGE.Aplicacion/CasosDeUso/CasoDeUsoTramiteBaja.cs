namespace SGE.Aplicacion;

public class CasoDeUsoTramiteBaja(ITramiteRepositorio repo,ServicioAutorizacionProvisorio servicio)
{
    public void Ejecutar(int id, int idUsuario){
        if (servicio.PoseeElPermiso(idUsuario)) {//Verifico si el usuario tiene permisos
            repo.TramiteBaja(id);
        } 
    }
}

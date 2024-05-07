namespace SGE.Aplicacion;

public class CasoDeUsoTramiteAlta(ITramiteRepositorio repo,ServicioAutorizacionProvisorio servicio) {
    public void Ejecutar(string? caratula, int idUsuario){
        if (servicio.PoseeElPermiso(idUsuario)) {//Verifico si el usuario tiene permisos
            repo.TramiteAlta(caratula,DateTime.Now,idUsuario);
        } 
    }
}

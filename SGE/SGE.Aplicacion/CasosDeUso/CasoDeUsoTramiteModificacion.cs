namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repo,ServicioAutorizacionProvisorio servicio)
{
    public void Ejecutar(Tramite tramite, string nuevoContenido, int idUsuario){
        if (servicio.PoseeElPermiso(idUsuario)) {//Verifico si el usuario tiene permisos
            repo.TramiteModificacion(tramite,nuevoContenido,idUsuario);
        } 
    }
}

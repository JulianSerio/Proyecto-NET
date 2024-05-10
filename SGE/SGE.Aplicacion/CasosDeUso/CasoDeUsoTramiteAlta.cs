namespace SGE.Aplicacion;

public class CasoDeUsoTramiteAlta(ITramiteRepositorio repo,ServicioAutorizacionProvisorio servicio) {
    public void Ejecutar(int expedienteID, EtiquetaTramite.Etiquetas etiqueta, string? contenido, int idUsuario){
        if (servicio.PoseeElPermiso(idUsuario)) {//Verifico si el usuario tiene permisos
            repo.TramiteAlta(expedienteID,etiqueta,contenido,DateTime.Now,idUsuario);
        } 
    }
}

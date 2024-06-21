namespace SGE.Aplicacion;

public class CasoDeUsoTramiteAlta(ITramiteRepositorio repo, ServicioAutorizacion autorizacion, ServicioActualizacionEstado actualizacion) {
    public void Ejecutar(int expedienteID, string contenido, string etiquetaTramite, int idUsuario){
        Permiso.Permisos permiso = Permiso.Permisos.TramiteAlta;
        EtiquetaTramite.Etiquetas etiqueta = (EtiquetaTramite.Etiquetas)Enum.Parse(typeof(EtiquetaTramite.Etiquetas), etiquetaTramite); //casteo de string a etiqueta
        if (autorizacion.PoseeElPermiso(permiso, idUsuario)) {//Verifico si el usuario tiene permisos
            TramiteValidador.validar(contenido);
            repo.TramiteAlta(expedienteID,contenido,idUsuario,etiqueta,DateTime.Now);
            actualizacion.ModificarExpediente(expedienteID, idUsuario, DateTime.Now); //se envia el llamado a la actualizacion 
        }else{
            throw new AutorizacionException("No posee el permiso necesario para crear un tramite");
        }
    }
    
}


namespace SGE.Aplicacion;

public class ServicioActualizacionEstado(IExpedienteRepositorio repoExpediente, ITramiteRepositorio repoTramite)
{
    public void ModificarExpediente(int idExpediente, int idUsuario, DateTime fechaModificacion) //cada vez que se cree, modifique o elimine el ultimo tramite se tiene que actualizar
    {
        EtiquetaTramite.Etiquetas? etiqueta = repoTramite.EtiquetaUltimoTramiteDeExpediente(idExpediente);//ir al repo de tramites //recuperar etiqueta del ultimo tramite del expediente
        if(etiqueta != null){
            EstadoExpediente.Estados? estado = EspecificacionCambioEstado.CambioDeEstadoAutomatico(etiqueta);    //enviarla a EspecificacionCambioEstado //recibir el estado correspondiente
            if(estado != null){ //si no es null quiere decir que tengo que actualizar el estado del expediente
                repoExpediente.ActualizarEstado(idExpediente, estado, fechaModificacion, idUsuario); //enviar al repositorio de expedientes el id y el estado nuevo
             }
        }
        
    }
}

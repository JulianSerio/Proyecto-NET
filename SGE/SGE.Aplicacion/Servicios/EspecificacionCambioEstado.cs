namespace SGE.Aplicacion;

public static class EspecificacionCambioEstado
{
    public static EstadoExpediente.Estados? CambioDeEstadoAutomatico(EtiquetaTramite.Etiquetas? etiqueta){
        switch (etiqueta)
        {
            case EtiquetaTramite.Etiquetas.Resolucion: return EstadoExpediente.Estados.ConResolucion;
            case EtiquetaTramite.Etiquetas.PaseAEstudio: return EstadoExpediente.Estados.ParaResolver;
            case EtiquetaTramite.Etiquetas.PaseAlArchivo:return EstadoExpediente.Estados.Finalizado;
            default: return null;
        }
    }
}

namespace SGE.Aplicacion;

public class EstadoExpediente {
    public enum Estados {
        RecienIniciado,
        ParaResolver,
        ConResolucion,
        EnNotificacion,
        Finalizado
    }
}

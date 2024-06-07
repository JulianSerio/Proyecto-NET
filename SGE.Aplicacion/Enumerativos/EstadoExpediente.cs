namespace SGE.Aplicacion;

public class EstadoExpediente {
    public Estados Estado { get; set; }

    public enum Estados {
        RecienIniciado,
        ParaResolver,
        ConResolucion,
        EnNotificacion,
        Finalizado
    }
}

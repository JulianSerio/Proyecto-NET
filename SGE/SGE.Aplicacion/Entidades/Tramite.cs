namespace SGE.Aplicacion;

public class Tramite {
    private int _id;
    public int ExpedienteID {get;set;} 
    private EtiquetaTramite? _etiquetaTramite;
    private string? _contenido;
    private DateTime _fechaCreacion;
    private DateTime _fechaModificacion;
    private int _idUsuarioModificador;

}

namespace SGE.Aplicacion;

public class Expediente{
    private int _id;
    private string? _caratula;
    private DateTime _fechaCreacion;
    private DateTime _fechaModificacion;
    private int _idUsuarioModificador;
    private EstadoExpediente? _estado;

    public Expediente(int id, string? caratula, DateTime creacion, DateTime modificacion, int idUsuarioModificador, EstadoExpediente? estado){
        _id = id;
        _caratula = caratula;
        _fechaCreacion = creacion;
        _fechaModificacion = modificacion;
        _idUsuarioModificador = idUsuarioModificador;
        _estado = estado;
    }
    
    public string? Caratula{
        get => _caratula;
    }
}

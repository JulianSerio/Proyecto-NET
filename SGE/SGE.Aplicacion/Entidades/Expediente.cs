namespace SGE.Aplicacion;

public class Expediente{
    private int _id {get;}
    private string? _caratula;
    private DateTime _fechaCreacion {get;}
    private DateTime _fechaModificacion {get;set;}
    private int? _idUsuarioModificador {get;set;}
    private EstadoExpediente.Estados _estado {get;}

    public Expediente(int id, string? caratula, DateTime fecha, int idUsuarioModificador){
        _id = id;
        _caratula = caratula;
        _fechaCreacion = fecha;
        _fechaModificacion = fecha;
        _idUsuarioModificador = idUsuarioModificador;
        _estado = EstadoExpediente.Estados.RecienIniciado;  
    }

    public Expediente(int id, string? caratula, DateTime fechaCreacion, DateTime fechaModificacion, int idUsuarioModificador, EstadoExpediente.Estados estado){
        _id = id;
        _caratula = caratula;
        _fechaCreacion = fechaCreacion;
        _fechaModificacion = fechaModificacion;
        _idUsuarioModificador = idUsuarioModificador;
        _estado = estado;  
    }
    
    public string? Caratula{
        get => _caratula;
        set => _caratula = value;
    }

    public DateTime FechaModificacion{
        get => _fechaModificacion;
    }

    public EstadoExpediente.Estados Estado{
        get => _estado;
    }

    public int IdExpediente{
        get => _id;
    }
}

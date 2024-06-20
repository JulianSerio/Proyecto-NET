namespace SGE.Aplicacion;

public class Expediente{
    public int Id {get;set;}
    public string? Caratula{get;set;}
    public DateTime FechaCreacion {get;set;}
    public DateTime FechaModificacion {get;set;}
    public int? IdUsuarioModificador {get;set;}
    public EstadoExpediente.Estados? Estado {get;set;}

    public Expediente(){}
    public Expediente(string? caratula, int idUsuarioModificador){
        Caratula = caratula;
        IdUsuarioModificador = idUsuarioModificador;
        Estado = EstadoExpediente.Estados.RecienIniciado;  
    }
    public Expediente(string? caratula, DateTime fecha, int idUsuarioModificador){
        Caratula = caratula;
        FechaCreacion = fecha;
        FechaModificacion = fecha;
        IdUsuarioModificador = idUsuarioModificador;
        Estado = EstadoExpediente.Estados.RecienIniciado;  
    }

    public Expediente(int id, string? caratula, DateTime fechaCreacion, DateTime fechaModificacion, int idUsuarioModificador, EstadoExpediente.Estados estado){
        Id = id;
        Caratula = caratula;
        FechaCreacion = fechaCreacion;
        FechaModificacion = fechaModificacion;
        IdUsuarioModificador = idUsuarioModificador;
        Estado = estado;  
    }
}

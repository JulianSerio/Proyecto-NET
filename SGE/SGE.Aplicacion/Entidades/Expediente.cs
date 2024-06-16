﻿namespace SGE.Aplicacion;

public class Expediente{
    private int _id {get;}
    private string? _caratula;
    private DateTime _fechaCreacion {get;}
    private DateTime _fechaModificacion {get;set;}
    private int? _idUsuarioModificador {get;set;}
    private EstadoExpediente.Estados _estado {get;}

    public Expediente(string? caratula, string apellido, int idUsuarioModificador){
        _caratula = caratula;
        _idUsuarioModificador = idUsuarioModificador;
        _estado = EstadoExpediente.Estados.RecienIniciado;  
    }
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
    
    public string? Caratula{get; set;}

    public DateTime FechaModificacion{get;set;}

    public EstadoExpediente.Estados Estado{get;}

    public int Id{get;}
    
    public DateTime FechaCreacion{get;}

    public int IdUsuarioModificador{get;}

}

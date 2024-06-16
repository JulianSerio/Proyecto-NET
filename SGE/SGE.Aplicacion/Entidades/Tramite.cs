using System.Reflection.Metadata.Ecma335;

namespace SGE.Aplicacion;

public class Tramite {
    private int _id;
    private int _expedienteId {get;set;} 
    private EtiquetaTramite.Etiquetas _etiquetaTramite {get;}
    private string? _contenido;
    private DateTime _fechaCreacion;
    private DateTime _fechaModificacion;
    private int _idUsuarioModificador;

    public Tramite(int id, int expedienteID, string? contenido, int idUsuarioModificador, EtiquetaTramite.Etiquetas etiquetaTramite){
        _id = id;
        _expedienteId = expedienteID;
        _contenido = contenido;
        _idUsuarioModificador = idUsuarioModificador;
        _etiquetaTramite = etiquetaTramite;
    }

    public Tramite(int id, int expedienteID, string? contenido, DateTime creacion, DateTime modificacion, int idUsuarioModificador, EtiquetaTramite.Etiquetas etiquetaTramite){
        _id = id;
        _expedienteId = expedienteID;
        _contenido = contenido;
        _fechaCreacion = creacion;
        _fechaModificacion = modificacion;
        _idUsuarioModificador = idUsuarioModificador;
        _etiquetaTramite = etiquetaTramite;
    }

    public string? Contenido{get;}
    public EtiquetaTramite.Etiquetas Etiqueta {get;}
    public DateTime FechaDeModificacion{get;}
    public int ExpedienteId{get;}
    public int id{get;}
    public DateTime FechaDeCreacion{get;}
    public int IdUsuarioModificador{get;}
}

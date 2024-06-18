using System.Reflection.Metadata.Ecma335;

namespace SGE.Aplicacion;

public class Tramite {
    public int Id {get;set;}
    public int ExpedienteId {get;set;} 
    public EtiquetaTramite.Etiquetas EtiquetaTramite {get;}
    public string? Contenido {get;set;}
    public DateTime FechaCreacion {get;set;}
    public DateTime FechaModificacion {get;set;}
    public int IdUsuarioModificador {get;set;}

    public Tramite( int expedienteID, string? contenido, int idUsuarioModificador, EtiquetaTramite.Etiquetas etiquetaTramite){
        ExpedienteId = expedienteID;
        Contenido = contenido;
        IdUsuarioModificador = idUsuarioModificador;
        EtiquetaTramite = etiquetaTramite;
    }

    public Tramite(){}
    public Tramite(int expedienteID, string? contenido, DateTime creacion, DateTime modificacion, int idUsuarioModificador, EtiquetaTramite.Etiquetas etiquetaTramite){
        Id = id;
        ExpedienteId = expedienteID;
        Contenido = contenido;
        FechaCreacion = creacion;
        FechaModificacion = modificacion;
        IdUsuarioModificador = idUsuarioModificador;
        EtiquetaTramite = etiquetaTramite;
    }

    //public string? Contenido{get;}
    //public EtiquetaTramite.Etiquetas Etiqueta {get;}
    //public DateTime FechaDeModificacion{get;}
    //public int ExpedienteId{get;}
    //public int id{get;}
    //public DateTime FechaDeCreacion{get;}
    //public int IdUsuarioModificador{get;}
}
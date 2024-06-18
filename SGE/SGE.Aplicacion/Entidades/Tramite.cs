using System.Reflection.Metadata.Ecma335;

namespace SGE.Aplicacion;

public class Tramite {
    public int Id {get;set;}
    public int ExpedienteId {get;set;} 
    public EtiquetaTramite.Etiquetas EtiquetaTramite {get;set;}
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
    public Tramite(int id,int expedienteID, string? contenido, DateTime creacion, DateTime modificacion, int idUsuarioModificador, EtiquetaTramite.Etiquetas etiquetaTramite){ //este es el contructor que se utiliza para devolver tramites a la UI, tiene que tener el 100% de los campos del tramite, no se puede obviar informacion porque esta se le presenta al usuario
        Id = id;
        ExpedienteId = expedienteID;
        Contenido = contenido;
        FechaCreacion = creacion;
        FechaModificacion = modificacion;
        IdUsuarioModificador = idUsuarioModificador;
        EtiquetaTramite = etiquetaTramite;
    }

    public Tramite(int expedienteID, string? contenido, DateTime creacion, DateTime modificacion, int idUsuarioModificador, EtiquetaTramite.Etiquetas etiquetaTramite){ //este es el contructor que se utiliza para devolver tramites a la UI, tiene que tener el 100% de los campos del tramite, no se puede obviar informacion porque esta se le presenta al usuario
        ExpedienteId = expedienteID;
        Contenido = contenido;
        FechaCreacion = creacion;
        FechaModificacion = modificacion;
        IdUsuarioModificador = idUsuarioModificador;
        EtiquetaTramite = etiquetaTramite;
    }
}
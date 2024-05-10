using System.Reflection.Metadata.Ecma335;

namespace SGE.Aplicacion;

public class Tramite {
    private int _id {get;}
    public int _expedienteId {get;set;} 
    private EtiquetaTramite _etiquetaTramite {get;}
    private string? _contenido;
    private DateTime _fechaCreacion;
    private DateTime _fechaModificacion;
    private int _idUsuarioModificador;

    public Tramite(int id, int expedienteID, string? contenido, DateTime creacion, DateTime modificacion, int idUsuarioModificador, EtiquetaTramite etiquetaTramite){

        _id = id;
        _expedienteId = expedienteID;
        _contenido = contenido;
        _fechaCreacion = creacion;
        _fechaModificacion = modificacion;
        _idUsuarioModificador = idUsuarioModificador;
        _etiquetaTramite = etiquetaTramite;
    }

    public string? Contenido{
        get => _contenido;
    }
    public EtiquetaTramite Etiqueta {
        get => _etiquetaTramite;
    }
}

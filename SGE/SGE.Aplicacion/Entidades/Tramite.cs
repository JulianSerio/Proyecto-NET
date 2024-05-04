using System.Reflection.Metadata.Ecma335;

namespace SGE.Aplicacion;

public class Tramite {
    private int _id;
    public int ExpedienteID {get;set;} 
    private EtiquetaTramite? _etiquetaTramite;
    private string? _contenido;
    private DateTime _fechaCreacion;
    private DateTime _fechaModificacion;
    private int _idUsuarioModificador;

    public Tramite(int id, int expedienteID, string? contenido, DateTime creacion, DateTime modificacion, int idUsuarioModificador, EtiquetaTramite etiquetaTramite){
        _id = id;
        _contenido = contenido;
        _fechaCreacion = creacion;
        _fechaModificacion = modificacion;
        _idUsuarioModificador = idUsuarioModificador;
        _etiquetaTramite = etiquetaTramite;
    }

    public string? Contenido{
        get => _contenido;
    }
}

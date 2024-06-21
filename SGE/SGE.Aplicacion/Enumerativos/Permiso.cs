namespace SGE.Aplicacion;

public class Permiso {
    public Permiso? Perm {get; set;}
    public enum Permisos{
        ExpedienteBaja,ExpedienteAlta,ExpedienteModificacion,
        TramiteAlta,TramiteBaja,TramiteModificacion,
    }    

}

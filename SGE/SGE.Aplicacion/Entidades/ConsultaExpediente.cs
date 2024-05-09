namespace SGE.Aplicacion;

public class ConsultaExpediente{
    public Expediente? Expediente {get;set;}
    public List<Tramite>? ListaTramites {get;set;}

    public ConsultaExpediente(Expediente expediente, List<Tramite> tramites){
        this.Expediente = expediente;
        this.ListaTramites = tramites;
    }

    public ConsultaExpediente(){
        
    }
}

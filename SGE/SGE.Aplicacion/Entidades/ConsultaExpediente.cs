namespace SGE.Aplicacion;

public class ConsultaExpediente{
    private Expediente? _expediente {get;}
    private List<Tramite>? _listaTramites {get;}

    public ConsultaExpediente(Expediente expediente, List<Tramite> tramites){
        this._expediente = expediente;
        this._listaTramites = tramites;
    }

}

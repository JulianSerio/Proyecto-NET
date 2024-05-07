namespace SGE.Repositorios;
using SGE.Aplicacion;
public class RepositorioTramiteTXT
{
    private readonly string _nameArch = "tramites.txt";
    private int _ultimoID;
    public RepositorioTramiteTXT(){
        if (File.Exists(_nameArch)){
            string[] contenido = File.ReadAllLines(_nameArch);
            if (contenido.Length > 0){
                int.TryParse(contenido[0],out _ultimoID);
            }
        }
        else{
            using (var sw = new StreamWriter(_nameArch)){}
            _ultimoID = 0;
        }
    }
    public void TramiteAlta(int id, int expedienteID, EtiquetaTramite etiqueta, String? contenido, DateTime creacion, int idUsuario)
    {
        try{  
            if(TramiteValidador.validar(contenido, idUsuario)){ //si el tramite es valido 
                _ultimoID++; //incremento ids generales
                this.GuardarIDs(); //almaceno el id 
                Tramite tramite = new Tramite(_ultimoID,expedienteID,contenido,creacion,creacion,idUsuario,etiqueta); //instancio el tramite
                using (var sw = new StreamWriter(_nameArch, true)){//abro el archivo en la ultima pos
                    sw.WriteLine($"{_ultimoID},{expedienteID},{contenido},{creacion},{creacion},{idUsuario},{etiqueta}");//guardo el tramite
                } 
            }
            else{  //sino es valido 
                throw new ValidacionException();
            }
        }
        catch (ValidacionException ex) {
            Console.WriteLine(ex.Message);
        }
    }
    public void TramiteBaja(int idTramite)
    {
        try
        {
            List<String> contenido = File.ReadAllLines(_nameArch).ToList(); //guardo todo el contenido en un vector
            bool encontre = false;
            int pos = 1;
            while ((pos < contenido.Count) && (!encontre))//recorro el vector de tramites
            {
                string[]datos = contenido.ElementAt(pos).Split(','); //guardo cada elemento del archivo en un vector y lo sepero por comas
                if (datos[0] == idTramite.ToString())
                {
                    contenido.RemoveAt(pos); //borro el elemento
                    encontre = true;
                    File.WriteAllLines(_nameArch,contenido); //escribo todo el contenido del archivo menos el registro buscado
                }
                pos++;
            }
            if (!encontre) { //si no lo encontre 
                throw new RepositorioException(); //tiro la excepcion
            }
        }
        catch(RepositorioException ex){
            Console.WriteLine(ex.Message);
        }
    }
    public void TramiteBajaPorExpediente(int idExpediente)
    {
        List<String> contenido = File.ReadAllLines(_nameArch).ToList(); //guardo todo el contenido en un vector
        int pos = 1;
        bool encontre = false;
        while (pos < contenido.Count)//recorro el vector de tramites
        {
            string[]datos = contenido.ElementAt(pos).Split(','); //guardo cada elemento del archivo en un vector y lo sepero por comas
            if (datos[1] == idExpediente.ToString())//si encontre uno con la idExpediente deseada
            {
                contenido.RemoveAt(pos); //borro el elemento
                encontre = true;
            }
            pos++;
        }
        if (encontre)//si borre al menos 1
        {
            File.WriteAllLines(_nameArch,contenido); //escribo todo el contenido del archivo menos los registro borrados
        }
    }
    private void TramiteModificacion()
    {
        //buscar tramite en archivo
        //si lo encontre tomo los datos nuevos
        //si lo encontre guardo el tramite actualizado en la pos actual
        //actualizo archivo
        //si no lo encontre tiro la exception
    }
    private void GuardarIDs(){
        using (var sw = new StreamWriter(_nameArch,false)){//abro el archivo 
            string[] contenido = File.ReadAllLines(_nameArch); //extraigo todas las lineas del archivo
            contenido[0] = _ultimoID.ToString(); //pongo en la primera posicion los id
            File.WriteAllLines(_nameArch,contenido); //escribo el contenido actualizado 

        } 
    }
}


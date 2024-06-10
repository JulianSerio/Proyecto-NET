namespace SGE.Repositorios;
using SGE.Aplicacion;
public class RepositorioTramiteTXT : ITramiteRepositorio{
    private readonly string _nameArch = "tramites.txt";
    private int _ultimoID;
    public RepositorioTramiteTXT(){
        if (File.Exists(_nameArch)){
            string[] contenido = File.ReadAllLines(_nameArch);
            if (contenido.Length > 0){
                int.TryParse(contenido[0],out _ultimoID);
            }
            else{
                File.WriteAllText(_nameArch, "0");
            }
        }
        else{
            using (var sw = new StreamWriter(_nameArch)){
                sw.WriteLine("0");
            }
            _ultimoID = 0;
        }
    }
    public void TramiteAlta(int expedienteID, EtiquetaTramite.Etiquetas etiqueta, String? contenido, DateTime creacion, int idUsuario){
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
            throw new ValidacionException();
        }
    }
    public int TramiteBaja(int idTramite){
        int idExpediente = -1;
        try{
            List<String> contenido = File.ReadAllLines(_nameArch).ToList(); //guardo todo el contenido en un vector
            bool encontre = false;
            int pos = 1;
            while ((pos < contenido.Count) && (!encontre))//recorro el vector de tramites
            {
                string[]datos = contenido.ElementAt(pos).Split(','); //guardo cada elemento del archivo en un vector y lo sepero por comas
                if (datos[0] == idTramite.ToString())
                {
                    idExpediente = int.Parse(datos[1]);
                    contenido.RemoveAt(pos); //borro el elemento
                    encontre = true;
                    File.WriteAllLines(_nameArch,contenido); //escribo todo el contenido del archivo menos el registro buscado
                }
                pos++;
            }
            if (!encontre) { //si no lo encontre 
                throw new RepositorioException(); //tiro la excepcion
            }
            else{
                return idExpediente;
            }
        }
        catch(RepositorioException ex){
            Console.WriteLine(ex.Message);
            return idExpediente;
        }
    }
    public int TramiteModificacion(int idTramite, string? nuevoContenido, int idModificador,EtiquetaTramite.Etiquetas etiqueta, DateTime fechaDeModificacion){
        int idExpediente = -1;
        try{
            if(TramiteValidador.validar(nuevoContenido, idModificador)){ //si el tramite pasa la validacion
                try{
                    List<String> datos = File.ReadAllLines(_nameArch).ToList(); //guardo todo el contenido en un vector
                    bool encontre = false;
                    int pos = 1;
                    while ((pos < datos.Count) && (!encontre)){ //mientras no llegue al final del archivo y no encontre lo deseado
                        string[]dato = datos.ElementAt(pos).Split(','); //guardo cada elemento del archivo en un vector y lo sepero por comas
                        if (dato[0] == idTramite.ToString()){ //busco la coincidencia en el id
                            datos[pos]=$"{dato[0]},{dato[1]},{nuevoContenido},{dato[3]},{fechaDeModificacion},{idModificador},{etiqueta}"; //se vuelve a cargar el expediente en la linea con el dato alterado
                            encontre = true;
                            idExpediente=int.Parse(dato[1]);
                        }
                        pos++;
                    }
                    if (!encontre) { //si no lo encontre 
                        throw new RepositorioException(); //tiro la excepcion
                    }
                    else{
                        File.WriteAllLines(_nameArch, datos);
                        return idExpediente;
                    }
                }
                catch(RepositorioException ex){
                    Console.WriteLine(ex.Message);
                    return idExpediente;
                }
            }
            else{
                throw new ValidacionException();
            }
        }
        catch (ValidacionException ex){
            Console.WriteLine(ex.Message);
            return idExpediente;
        }
    }
    public List<Tramite>? BusquedaPorEtiqueta(EtiquetaTramite.Etiquetas etiqueta){
        try{
            List<Tramite>? tramites = new List<Tramite>();
            int id;
            int idExpediente;
            string contenido;
            DateTime fechaCreacion;
            DateTime fechaModificacion;
            int idUsuarioModificador;
            EtiquetaTramite.Etiquetas etiquetaTramite;
            using (var reader = new StreamReader(_nameArch)){ //abro el archivo
                    string? line;
                    reader.ReadLine(); //saltea la posicion 0
                    while ((line = reader.ReadLine()) != null) { //mientras que queden lineas sin leer
                        string[] datos = line.Split(','); //divido todos los elementos separados por "," y los guardo en un vector
                        etiquetaTramite = (EtiquetaTramite.Etiquetas)Enum.Parse(typeof(EtiquetaTramite.Etiquetas), datos[6]);
                        if(etiqueta == etiquetaTramite){
                            id = int.Parse(datos[0]);
                            idExpediente = int.Parse(datos[1]);
                            contenido = datos[2];
                            fechaCreacion = DateTime.Parse(datos[3]);
                            fechaModificacion = DateTime.Parse(datos[4]);
                            idUsuarioModificador = int.Parse(datos[5]);
                            Tramite tramite = new Tramite(id, idExpediente, contenido, fechaCreacion, fechaModificacion,idUsuarioModificador, etiquetaTramite); //creo el tramite con los datos a guardar en la lista
                            tramites.Add(tramite);
                        }
                    }
            }
            if(tramites.Count == 0){
                throw new RepositorioException();
            }
            return tramites; //devuelvo la lista cargada
        }
        catch(RepositorioException ex){
            Console.WriteLine(ex.Message);
            return null;
        }
    }
    public EtiquetaTramite.Etiquetas? EtiquetaUltimoTramiteDeExpediente(int idExpediente){
        List<Tramite>? tramites = TramitesExpediente(idExpediente);
        try{
            if (tramites != null){
                Tramite tramite = tramites.Last();
                return tramite.Etiqueta;
            }
            else{
                Console.WriteLine("ayuda loco");
                throw new RepositorioException();
                
            }
        }
        catch(RepositorioException ex){
            Console.WriteLine(ex.Message);
            return null;
        }
        
    }
    internal List<Tramite>? TramitesExpediente(int idExpediente){
        try{
            List<Tramite>? tramites = new List<Tramite>();
            int id;
            string contenido;
            DateTime fechaCreacion;
            DateTime fechaModificacion;
            int idUsuarioModificador;
            EtiquetaTramite.Etiquetas etiquetaTramite;
            using (var reader = new StreamReader(_nameArch)){ //abro el archivo
                    string? line;
                    reader.ReadLine(); //saltea la posicion 0
                    while ((line = reader.ReadLine()) != null) { //mientras que queden lineas sin leer
                        string[] datos = line.Split(','); //divido todos los elementos separados por "," y los guardo en un vector
                        if(datos[1] == idExpediente.ToString())//si encuentro un tramite que coincida con el idExpediente
                        {
                            id = int.Parse(datos[0]);
                            contenido = datos[2];
                            fechaCreacion = DateTime.Parse(datos[3]);
                            fechaModificacion = DateTime.Parse(datos[4]);
                            idUsuarioModificador = int.Parse(datos[5]);
                            etiquetaTramite = (EtiquetaTramite.Etiquetas)Enum.Parse(typeof(EtiquetaTramite.Etiquetas), datos[6]);
                            Tramite tramite = new Tramite(id, idExpediente, contenido, fechaCreacion, fechaModificacion, idUsuarioModificador, etiquetaTramite); //creo el tramite con los datos a guardar en la lista
                            tramites.Add(tramite);
                        }
                    }
            }
            if(tramites.Count == 0){
                throw new RepositorioException();
            }
            return tramites; //devuelvo la lista cargada
        }
        catch(RepositorioException ex){
            Console.WriteLine(ex.Message);
            return null;
        }
        
    }
    internal void TramiteBajaPorExpediente(int idExpediente){
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
    private void GuardarIDs(){
        string[] contenido = File.ReadAllLines(_nameArch); //extraigo todas las lineas del archivo
        contenido[0] = _ultimoID.ToString(); //pongo en la primera posicion los id
        File.WriteAllLines(_nameArch,contenido); //escribo el contenido actualizado 
    }
}
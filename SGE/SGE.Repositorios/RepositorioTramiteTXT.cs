namespace SGE.Repositorios;
using SGE.Aplicacion;
public class RepositorioTramiteTXT : ITramiteRepositorio
{
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
                actualizarEtiquetaExpediente(expedienteID);
            }
            else{  //sino es valido 
                throw new ValidacionException();
            }
        }
        catch (ValidacionException ex) {
            Console.WriteLine(ex.Message);
        }
    }
    public void TramiteBaja(int idTramite){
        try
        {
            List<String> contenido = File.ReadAllLines(_nameArch).ToList(); //guardo todo el contenido en un vector
            bool encontre = false;
            int pos = 1;
            int idExpediente = 0;
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
                actualizarEtiquetaExpediente(idExpediente);//reviso que no haya que cambiar etiqueta del expediente
            }
        }
        catch(RepositorioException ex){
            Console.WriteLine(ex.Message);
        }
    }
    public void TramiteModificacion(Tramite tramite, string nuevoContenido, int idModificador,EtiquetaTramite.Etiquetas etiqueta){
        try{
            int idExpediente = 0;
            if(TramiteValidador.validar(nuevoContenido, idModificador)){ //si el tramite pasa la validacion
                try{
                    List<String> datos = File.ReadAllLines(_nameArch).ToList(); //guardo todo el contenido en un vector
                    bool encontre = false;
                    int pos = 1;
                    while ((pos < datos.Count) && (!encontre)){ //mientras no llegue al final del archivo y no encontre lo deseado
                        string[]dato = datos.ElementAt(pos).Split(','); //guardo cada elemento del archivo en un vector y lo sepero por comas
                        if (dato[0] == tramite.id.ToString()){ //busco la coincidencia en el id
                            idExpediente = tramite.expedienteId;
                            datos[pos]=$"{dato[0]},{dato[1]},{nuevoContenido},{dato[3]},{DateTime.Now},{idModificador},{etiqueta}"; //se vuelve a cargar el expediente en la linea con el dato alterado
                            encontre = true;
                        }
                        pos++;
                    }
                    if (!encontre) { //si no lo encontre 
                        throw new RepositorioException(); //tiro la excepcion
                    }
                    else{
                        File.WriteAllLines(_nameArch, datos);
                        actualizarEtiquetaExpediente(idExpediente);
                    }
                }
                catch(RepositorioException ex){
                    Console.WriteLine(ex.Message);
                }
            }
            else{
                throw new ValidacionException();
            }
        }
        catch (ValidacionException ex){
            Console.WriteLine(ex.Message);
        }
    }
    public List<Tramite>? TramiteBusquedaTodos(){
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
                    id = int.Parse(datos[0]);
                    idExpediente = int.Parse(datos[1]);
                    contenido = datos[2];
                    fechaCreacion = DateTime.Parse(datos[3]);
                    fechaModificacion = DateTime.Parse(datos[4]);
                    idUsuarioModificador = int.Parse(datos[5]);
                    etiquetaTramite = (EtiquetaTramite.Etiquetas)Enum.Parse(typeof(EtiquetaTramite.Etiquetas), datos[6]);
                    Tramite tramite = new Tramite(id, idExpediente, contenido, fechaCreacion, fechaModificacion,idUsuarioModificador, etiquetaTramite); //creo el tramite con los datos a guardar en la lista
                    tramites.Add(tramite);
                }
        }
        return tramites; //devuelvo la lista cargada
    }
    public EtiquetaTramite.Etiquetas? EtiquetaUltimoTramiteDeExpediente(int idExpediente){
        List<Tramite>? tramites = TramitesExpediente(idExpediente);
        try
        {
            if (tramites != null)
            {
                Tramite tramite = tramites.Last();
                return tramite.Etiqueta;
            }
            else
            {
                throw new RepositorioException();
            }
        }
        catch(RepositorioException ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
        
    }
    public void ActualizarEtiqueta(int idTramite, EtiquetaTramite.Etiquetas etiqueta){
        try{
            List<String> contenido = File.ReadAllLines(_nameArch).ToList(); //guardo todo el contenido en un vector
            bool encontre = false;
            int pos = 1;
            int idExpediente = 0;
            while ((pos < contenido.Count) && (!encontre)){ //mientras no llegue al final del archivo y no encontre el archivo
                string[]datos = contenido.ElementAt(pos).Split(','); //guardo cada elemento del archivo en un vector y lo sepero por comas
                if (datos[0] == idTramite.ToString()){ //busco la coincidencia en el id
                    idExpediente = int.Parse(datos[1]);
                    contenido[pos]=$"{datos[0]},{datos[1]},{datos[2]},{datos[3]},{datos[4]},{datos[5]},{etiqueta}"; //se vuelve a cargar el expediente en la linea con los datos alterados
                    encontre = true;
                }
                pos++;
            }
            if (!encontre) { //si no lo encontre 
                throw new RepositorioException(); //tiro la excepcion
            }
            else{
                File.WriteAllLines(_nameArch, contenido);
                actualizarEtiquetaExpediente(idExpediente);
            }
        }
        catch(RepositorioException ex){
            Console.WriteLine(ex.Message);
        }
    }
    internal List<Tramite>? TramitesExpediente(int idExpediente){
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
        return tramites; //devuelvo la lista cargada
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
    private void actualizarEtiquetaExpediente(int idExpediente){
        var etiqueta = EtiquetaUltimoTramiteDeExpediente(idExpediente);
        var repositorioExpediente = new RepositorioExpedienteTXT(); 
        switch (etiqueta)
        {
            case EtiquetaTramite.Etiquetas.Resolucion:
            repositorioExpediente.ActualizarEstado(idExpediente,EstadoExpediente.Estados.ConResolucion);
            break;
            case EtiquetaTramite.Etiquetas.PaseAEstudio:
            repositorioExpediente.ActualizarEstado(idExpediente,EstadoExpediente.Estados.ParaResolver);
            break;
            case EtiquetaTramite.Etiquetas.PaseAlArchivo:
            repositorioExpediente.ActualizarEstado(idExpediente,EstadoExpediente.Estados.Finalizado);
            break;
        }
    }
    private void GuardarIDs(){
        using (var sw = new StreamWriter(_nameArch,false)){//abro el archivo 
            string[] contenido = File.ReadAllLines(_nameArch); //extraigo todas las lineas del archivo
            contenido[0] = _ultimoID.ToString(); //pongo en la primera posicion los id
            File.WriteAllLines(_nameArch,contenido); //escribo el contenido actualizado 

        } 
    }
}


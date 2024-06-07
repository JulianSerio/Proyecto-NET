namespace SGE.Repositorios;

using System.Collections.Generic;
using SGE.Aplicacion;

public class RepositorioExpedienteTXT : IExpedienteRepositorio{
    private readonly string _nameArch = "expedientes.txt";
    private int _ultimoID;

    public RepositorioExpedienteTXT(){
        if (File.Exists(_nameArch)){ //si el archivo existe
            string[] contenido = File.ReadAllLines(_nameArch); //lee todo el contenido y lo guarda en un vector
            if (contenido.Length > 0){ //si el archivo no esta vacio
                int.TryParse(contenido[0],out _ultimoID); //copia el ultimo id y lo guarda en la variable
            }
            else{
                File.WriteAllText(_nameArch, "0"); //si el archivo esta vacio escribe "0" en el archivo
            }
        }
        else{ //si el archivo no esta creado
            using (var sw = new StreamWriter(_nameArch)){ //el archivo se crea
                sw.WriteLine("0"); //se escribe "0" en el archivo
            }
            _ultimoID = 0; //se instancia el ultimo id
        }
    }

    public void ExpedienteAlta(string? caratula,DateTime fecha, int idUsuario) {
        _ultimoID++; //incremento ids generales
        this.GuardarIDs(); //almaceno el id 
        Expediente expediente = new Expediente(_ultimoID,caratula,fecha,idUsuario); //instancio el expediente
        using (var sw = new StreamWriter(_nameArch, true)){//abro el archivo en la ultima pos
            sw.WriteLine($"{_ultimoID},{caratula},{fecha},{expediente.FechaModificacion},{idUsuario},{expediente.Estado}"); //grabo todo el expediente en el archivo
        } 
    }

    public void ExpedienteBaja(int idExpediente){
        List<String> contenido = File.ReadAllLines(_nameArch).ToList(); //guardo todo el contenido en un vector
        bool encontre = false;
        int pos = 1;
        while ((pos <= contenido.Count-1) && (!encontre)){ //mientras no llegue al final del archivo y no encontre el archivo
            string[]datos = contenido.ElementAt(pos).Split(','); //guardo cada elemento del archivo en un vector y lo sepero por comas
            if (datos[0] == idExpediente.ToString()){ //busco la coincidencia en el id
                contenido.RemoveAt(pos); //borro el elemento
                encontre = true;
                RepositorioTramiteTXT repositorioTramites = new RepositorioTramiteTXT(); //instancio el repositorio
                repositorioTramites.TramiteBajaPorExpediente(int.Parse(datos[0])); //envio el id del expediente al repositorio de tramites para que borre todos los tramites asociados a ese expediente
                File.WriteAllLines(_nameArch,contenido); //escribo todo el contenido del archivo menos el registro borrado
            }
            pos++;
        }
    }

    public ConsultaExpediente ExpedienteBusquedaID(int idExpediente){
        bool encontre = false;
        using (var reader = new StreamReader(_nameArch)){ //abro el archivo
            ConsultaExpediente consulta = new ConsultaExpediente();
            string? line;
            while (((line = reader.ReadLine()) != null) && (!encontre)) { //mientras que queden lineas sin leer
                string[] datos = line.Split(','); //divido todos los elementos separados por "," y los guardo en un vector
                
                if (datos.Length == 6 && datos[0] == idExpediente.ToString()){ //si la cantidad de datos es igual a 6 (saltea la primera posicion que contiene a los id) y los ids coinciden
                    string caratula = datos[1];
                    DateTime fechaCreacion = DateTime.Parse(datos[2]);
                    DateTime fechaModificacion = DateTime.Parse(datos[3]);
                    int idUsuarioModificador = int.Parse(datos[4]);
                    EstadoExpediente.Estados estado = (EstadoExpediente.Estados)Enum.Parse(typeof(EstadoExpediente.Estados), datos[5]); //casteo de string a un enum de tipo Estados
                    Expediente expediente = new Expediente(idExpediente, caratula, fechaCreacion, fechaModificacion, idUsuarioModificador, estado);//cargo el expediente con los datos
                    List<Tramite> tramites = ObtenerTramitesExpediente(idExpediente) ?? new List<Tramite>(); //obtengo la lista de tramites asociados al expediente
                    consulta.Expediente= expediente;
                    consulta.ListaTramites = tramites;
                    encontre=true; //cuando encuentra corta
                }
            }
            if(!encontre){
                throw new RepositorioException();
            }
            return consulta;
        }
    }

    public List<Expediente> ExpedienteBusquedaTodos(){
        List<Expediente>? expedientes = new List<Expediente>();
        int idExpediente;
        DateTime fechaCreacion;
        DateTime fechaModificacion;
        int idUsuarioModificador;
        string caratula;
        EstadoExpediente.Estados estado;
        using (var reader = new StreamReader(_nameArch)){ //abro el archivo
                string? line;
                reader.ReadLine(); //saltea la posicion 0
                while ((line = reader.ReadLine()) != null) { //mientras que queden lineas sin leer
                    string[] datos = line.Split(','); //divido todos los elementos separados por "," y los guardo en un vector
                    idExpediente = int.Parse(datos[0]);
                    caratula = datos[1];
                    fechaCreacion = DateTime.Parse(datos[2]);
                    fechaModificacion = DateTime.Parse(datos[3]);
                    idUsuarioModificador = int.Parse(datos[4]);
                    estado = (EstadoExpediente.Estados)Enum.Parse(typeof(EstadoExpediente.Estados), datos[5]);
                    Expediente expediente = new Expediente(idExpediente, caratula, fechaCreacion, fechaModificacion, idUsuarioModificador, estado); //creo el expediente con los datos a guardar en la lista
                    expedientes.Add(expediente);
                }
        }
        return expedientes; //devuelvo la lista cargada
    }

    public void ExpedienteModificacion(int idExpediente, DateTime fechaModificacion, string? caratula, int idUsuario){
        List<String> contenido = File.ReadAllLines(_nameArch).ToList(); //guardo todo el contenido en un vector
        bool encontre = false;
        int pos = 1;
        while ((pos <= contenido.Count-1) && (!encontre)){ //mientras no llegue al final del archivo y no encontre el archivo
            string[]datos = contenido.ElementAt(pos).Split(','); //guardo cada elemento del archivo en un vector y lo sepero por comas
            if (datos[0] == idExpediente.ToString()){ //busco la coincidencia en el id
                contenido[pos]=$"{datos[0]},{caratula},{datos[2]},{fechaModificacion},{idUsuario},{datos[5]}"; //se vuelve a cargar el expediente en la linea con los datos alterados
                encontre = true;
            }
            pos++;
        }
        if(encontre){
            File.WriteAllLines(_nameArch, contenido);
        }
        else{
            throw new RepositorioException(); //si no encuentro el archivo, envio la excepcion
        }
    }       

    private void GuardarIDs(){
            string[] contenido = File.ReadAllLines(_nameArch); //extraigo todas las lineas del archivo
            contenido[0] = _ultimoID.ToString(); //pongo en la primera posicion los id
            File.WriteAllLines(_nameArch,contenido); //escribo el contenido actualizado 
    }

    public List<Tramite>? ObtenerTramitesExpediente(int idExpediente){
        RepositorioTramiteTXT repositorioTramites = new RepositorioTramiteTXT(); //instancio el repositorio
        return repositorioTramites.TramitesExpediente(idExpediente);//retorna la lista obtenida del repositorio de tramites
    }

    public void ActualizarEstado(int idExpediente, EstadoExpediente.Estados? estado, DateTime fechaDeModificacion){
        List<String> contenido = File.ReadAllLines(_nameArch).ToList(); //guardo todo el contenido en un vector
        bool encontre = false;
        int pos = 1;
        while ((pos <= contenido.Count-1) && (!encontre)){ //mientras no llegue al final del archivo y no encontre el archivo
            string[]datos = contenido.ElementAt(pos).Split(','); //guardo cada elemento del archivo en un vector y lo sepero por comas
            if (datos[0] == idExpediente.ToString()){ //busco la coincidencia en el id
                contenido[pos]=$"{datos[0]},{datos[1]},{datos[2]},{fechaDeModificacion},{datos[4]},{estado}"; //se vuelve a cargar el expediente en la linea con los datos alterados
                encontre = true;
            }
            pos++;
        }
        if(encontre){
            File.WriteAllLines(_nameArch, contenido);
        }
    }
}



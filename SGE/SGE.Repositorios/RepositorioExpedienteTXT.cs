﻿namespace SGE.Repositorios;

using System.Collections.Generic;
using SGE.Aplicacion;

public class RepositorioExpedienteTXT : IExpedienteRepositorio{
    private readonly string _nameArch = "expedientes.txt";
    private int _ultimoID;

    public RepositorioExpedienteTXT(){
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

    public void ExpedienteAlta(string? caratula,DateTime fecha, int idUsuario) {
        try{  
            if(ExpedienteValidador.validar(caratula, idUsuario)){ //si el expediente es valido 
                _ultimoID++; //incremento ids generales
                this.GuardarIDs(); //almaceno el id 
                Expediente expediente = new Expediente(_ultimoID,caratula,fecha,idUsuario); //instancio el expediente
                using (var sw = new StreamWriter(_nameArch, true)){//abro el archivo en la ultima pos
                    sw.WriteLine($"{_ultimoID},{caratula},{fecha},{expediente.FechaModificacion},{idUsuario},{expediente.Estado}");
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

    public void ExpedienteBaja(int idExpediente){
        try{
            List<String> contenido = File.ReadAllLines(_nameArch).ToList(); //guardo todo el contenido en un vector
            bool encontre = false;
            int pos = 1;
            while ((pos <= contenido.Count-1) && (!encontre)){ //mientras no llegue al final del archivo y no encontre el archivo
                string[]datos = contenido.ElementAt(pos).Split(','); //guardo cada elemento del archivo en un vector y lo sepero por comas
                if (datos[0] == idExpediente.ToString()){ //busco la coincidencia en el id
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

    public ConsultaExpediente ExpedienteBusquedaID(int idExpediente){
        try{
            using (var reader = new StreamReader(_nameArch)){
                string? line;
                while ((line = reader.ReadLine()) != null) {
                    string[] datos = line.Split(',');

                    if (datos.Length == 6 && datos[0] == idExpediente.ToString()){
                        string caratula = datos[1];
                        DateTime fechaCreacion = DateTime.Parse(datos[2]);
                        DateTime fechaModificacion = DateTime.Parse(datos[3]);
                        int idUsuarioModificador = int.Parse(datos[4]);
                        EstadoExpediente.Estados estado = (EstadoExpediente.Estados)Enum.Parse(typeof(EstadoExpediente.Estados), datos[5]);
                        Expediente expediente = new Expediente(idExpediente, caratula, fechaCreacion, fechaModificacion, idUsuarioModificador, estado);
                        List<Tramite> tramites = ObtenerTramitesExpediente(idExpediente) ?? new List<Tramite>();
                        return new ConsultaExpediente(expediente, tramites);
                    }
                }
            }
            // si no se encontro el expediente, lanzar una excepción
            throw new RepositorioException("Expediente no encontrado");
        }
        catch (FileNotFoundException ex) {
            Console.WriteLine(ex.Message);
        }
        catch (RepositorioException ex){
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex){
            Console.WriteLine("Error: " + ex.Message);
        }
        return new ConsultaExpediente();
    }

    public List<Expediente> ExpedienteBusquedaTodos()
    {
        throw new NotImplementedException();
    }

    public void ExpedienteModificacion(Expediente expediente)
    {
        throw new NotImplementedException();
    }

    private void GuardarIDs(){
        using (var sw = new StreamWriter(_nameArch,false)){//abro el archivo 
            string[] contenido = File.ReadAllLines(_nameArch); //extraigo todas las lineas del archivo
            contenido[0] = _ultimoID.ToString(); //pongo en la primera posicion los id
            File.WriteAllLines(_nameArch,contenido); //escribo el contenido actualizado 

        } 
    }

    
    private List<Tramite>? ObtenerTramitesExpediente(int idExpediente){
        RepositorioTramiteTXT repositorioTramites = new RepositorioTramiteTXT();
        return null;
    }
}

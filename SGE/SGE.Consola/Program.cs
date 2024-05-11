using SGE.Aplicacion;
using SGE.Repositorios;

//Repositorios
IExpedienteRepositorio repositorioExpedientes = new RepositorioExpedienteTXT();
ITramiteRepositorio repositorioTramites = new RepositorioTramiteTXT();

//Servicios
ServicioAutorizacionProvisorio autorizacion = new ServicioAutorizacionProvisorio();
ServicioActualizacionEstado actualizacion = new ServicioActualizacionEstado(repositorioExpedientes, repositorioTramites);

//Casos de uso expedientes
var altaExpediente = new CasoDeUsoExpedienteAlta(repositorioExpedientes, autorizacion);
var bajaExpediente = new CasoDeUsoExpedienteBaja(repositorioExpedientes, autorizacion);
var consultarExpedientePorId = new CasoDeUsoExpedienteConsultaPorId(repositorioExpedientes);
var consultarExpedienteTodos = new CasoDeUsoExpedienteConsultaTodos(repositorioExpedientes);
var modificarExpediente = new CasoDeUsoExpedienteModificacion(autorizacion, repositorioExpedientes);

//Casos de uso tramites
var altaTramite = new CasoDeUsoTramiteAlta(repositorioTramites, autorizacion, actualizacion);
var bajaTramite = new CasoDeUsoTramiteBaja(repositorioTramites, autorizacion, actualizacion);
var consultarTramitePorEtiqueta = new CasoDeUsoTramiteConsultaPorEtiqueta(repositorioTramites);
var modificarTramite = new CasoDeUsoTramiteModificacion(repositorioTramites, autorizacion, actualizacion);

//Test AltaExpediente

altaExpediente.Ejecutar("Exp01", 1);
altaExpediente.Ejecutar("Exp02", 1);
altaExpediente.Ejecutar("", 1); //excepcion de validacion de expediente
altaExpediente.Ejecutar("TestDe0", 0); //usuario no autorizado
altaExpediente.Ejecutar("TestDeMayoresA1", 2); //usuario no autorizado
altaExpediente.Ejecutar(null, 1); //excepcion de validacion de expediente

//Test AltaTramite
EtiquetaTramite.Etiquetas etiqueta = EtiquetaTramite.Etiquetas.PaseAlArchivo;
altaTramite.Ejecutar(1, etiqueta, "Tram01", 1);
altaTramite.Ejecutar(2, etiqueta, "Tram02", 1);
altaTramite.Ejecutar(1, etiqueta, "TestDe0", 0);//usuario no autorizado
altaTramite.Ejecutar(1, etiqueta, "TestDeMayorA1", 2);//usuario no autorizado
altaTramite.Ejecutar(1, etiqueta, "", 1);//excepcion de validacion de expediente

//Test BajaTramite
bajaTramite.Ejecutar(2, 1);

//Test BajaExpediente

bajaExpediente.Ejecutar(1, 1);//elimina al expediente con id=1 y sus tramites asociados
bajaExpediente.Ejecutar(999, 1);//excepcion de repositorio, el id=999 no se encuentra en el repositorio


//Test ConsultarExpedientesTodos

altaExpediente.Ejecutar("Exp03", 1);
List<Expediente> expedientes = consultarExpedienteTodos.Ejecutar();

foreach (Expediente ex in expedientes){
    Console.WriteLine($"Caratula:{ex.Caratula}, Estado:{ex.Estado}, Fecha de modificacion:{ex.FechaModificacion}");
}

//Test ModificacionTramite
altaTramite.Ejecutar(1, etiqueta, "Tram03", 1);
EtiquetaTramite.Etiquetas etiqueta1 = EtiquetaTramite.Etiquetas.Resolucion;
modificarTramite.Ejecutar(1, "TramiteModificado01", 1, etiqueta1);


//Test ModificarExpediente

modificarExpediente.Ejecutar(2,1,"ExpedienteModificado02");

List<Expediente>expedientes2 = consultarExpedienteTodos.Ejecutar();

foreach (Expediente ex in expedientes2){
    Console.WriteLine($"Caratula:{ex.Caratula}, Estado:{ex.Estado}, Fecha de modificacion:{ex.FechaModificacion}");
}

modificarExpediente.Ejecutar(999, 1, "TestExpedienteInexistente"); //excepcion de repositorio, el id=999 no se encuentra en el repositorio

//Test ConsultaTramitePorEtiqueta
EtiquetaTramite.Etiquetas etiqueta2 = EtiquetaTramite.Etiquetas.PaseAlArchivo;
List<Tramite>? tramites = consultarTramitePorEtiqueta.Ejecutar(etiqueta2);
if(tramites != null){
    foreach (Tramite tr in tramites){
        Console.WriteLine(tr.Contenido);
    }
}


//Test ConsultarExpedientePorId

ConsultaExpediente? consul1 = consultarExpedientePorId.Ejecutar(2); //lista al expediente con id 2 con todos sus tramites
if(consul1.Expediente != null){
    Console.WriteLine($"Caratula:{consul1.Expediente.Caratula}, Estado:{consul1.Expediente.Estado}, Fecha de modificacion:{consul1.Expediente.FechaModificacion}"); //imprime la caratula del expediente
    if(consul1.ListaTramites != null){
        foreach (Tramite tramite in consul1.ListaTramites)
        {
            Console.WriteLine(tramite.Contenido); //imprime el contenido de los tramites
        }    
    }
}
ConsultaExpediente? consul2 = consultarExpedientePorId.Ejecutar(999); //excepcion de repositorio, el id=999 no se encuentra en el repositorio
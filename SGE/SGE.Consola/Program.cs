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

TestAltaExpediente(altaExpediente);
TestBajaExpediente(bajaExpediente);
TestModificarExpediente(modificarExpediente);
TestConsultarExpedientesTodos(consultarExpedienteTodos);
TestConsultarExpedientePorId(consultarExpedientePorId);

TestAltaTramite(altaTramite);
TestBajaTramite(bajaTramite);
TestModificarTramite(modificarTramite);
TestConsultaTramitePorEtiqueta(consultarTramitePorEtiqueta);

static void TestAltaExpediente(CasoDeUsoExpedienteAlta altaExpediente){
    Console.WriteLine("---------------------Alta Expediente--------------------------");
    altaExpediente.Ejecutar("Exp01", 1);
    altaExpediente.Ejecutar("Exp02", 1);
    altaExpediente.Ejecutar("Exp03", 1);
    altaExpediente.Ejecutar("Exp04", 1);
    Console.WriteLine("Test de excepciones de validacion de expediente: ");
    altaExpediente.Ejecutar("", 1); //Test caratula vacia
    altaExpediente.Ejecutar(null, 1); //Test caratula null
    altaExpediente.Ejecutar(" ", 1); //Test caratula con un blank
    Console.WriteLine("Test de excepciones de autorizacion: ");
    altaExpediente.Ejecutar("TestIdUsuario0", 0);
    altaExpediente.Ejecutar("TestIdUsuarioMayorA1", 2);
    Console.WriteLine("--------------------------------------------------------------");
}

static void TestBajaExpediente(CasoDeUsoExpedienteBaja bajaExpediente){
    Console.WriteLine("---------------------Baja Expediente--------------------------");
    bajaExpediente.Ejecutar(2, 1);
    Console.WriteLine("Test de excepciones de repositorio: ");
    bajaExpediente.Ejecutar(999, 1);
    bajaExpediente.Ejecutar(2, 1);
    Console.WriteLine("Test de excepciones de autorizacion: ");
    bajaExpediente.Ejecutar(1, 0);
    bajaExpediente.Ejecutar(1, 2);
    Console.WriteLine("--------------------------------------------------------------");
}

static void TestModificarExpediente(CasoDeUsoExpedienteModificacion modificarExpediente){
    Console.WriteLine("---------------------Modificacion Expediente--------------------------");
    modificarExpediente.Ejecutar(1,1,"ExpedienteModificado01");
    Console.WriteLine("Test de excepciones de validacion de expediente: ");
    modificarExpediente.Ejecutar(1,1,""); //Test caratula vacia
    modificarExpediente.Ejecutar(1,1,null); //Test caratula null
    modificarExpediente.Ejecutar(1,1," "); //Test caratula con un blank
    Console.WriteLine("Test de excepciones de repositorio: ");
    modificarExpediente.Ejecutar(-1,1,"TestIdExpedienteInexistente");
    modificarExpediente.Ejecutar(999,1,"TestIdExpedienteInexistente");
    Console.WriteLine("Test de excepciones de autorizacion: ");
    modificarExpediente.Ejecutar(1,0,"TestIdUsuario0");
    modificarExpediente.Ejecutar(1,2,"TestIdUsuarioMayorA1");
    Console.WriteLine("---------------------------------------------------------------------");
}

static void TestConsultarExpedientesTodos(CasoDeUsoExpedienteConsultaTodos consultarExpedienteTodos){
    Console.WriteLine("---------------------Consultar todos los Expedientes--------------------------");
    List<Expediente> expedientes = consultarExpedienteTodos.Ejecutar();
    foreach (Expediente ex in expedientes)
    {
        Console.WriteLine($"Caratula:{ex.Caratula}, Estado:{ex.Estado}, Fecha de modificacion:{ex.FechaModificacion}");
    }
    Console.WriteLine("------------------------------------------------------------------------------");
}

static void TestConsultarExpedientePorId(CasoDeUsoExpedienteConsultaPorId consultarExpedientePorId){
    Console.WriteLine("-----------------------------------Consultar Expedientes por ID-------------------------------------------");
    ConsultaExpediente? consul1 = consultarExpedientePorId.Ejecutar(1); // Lista al expediente con id 1 con todos sus tramites
    if (consul1?.Expediente != null)
    {
        Console.WriteLine($"ID:{consul1.Expediente.IdExpediente} Caratula:{consul1.Expediente.Caratula}, Estado:{consul1.Expediente.Estado}, Fecha de modificacion:{consul1.Expediente.FechaModificacion}"); // Imprime la caratula del expediente
        if (consul1.ListaTramites != null)
        {
            foreach (Tramite tramite in consul1.ListaTramites)
            {
                Console.WriteLine($"ID:{tramite.id}, Contenido:{tramite.Contenido}, Etiqueta:{tramite.Etiqueta}, Fecha de modificacion:{tramite.FechaDeModificacion}"); // Imprime el contenido de los tramites
            }
        }
    }
    Console.WriteLine("Test de excepciones de repositorio: ");
    ConsultaExpediente? consul2 = consultarExpedientePorId.Ejecutar(999); // Excepcion de repositorio, el id=999 no se encuentra en el repositorio
    Console.WriteLine("---------------------------------------------------------------------------------------------------------");
}

static void TestAltaTramite(CasoDeUsoTramiteAlta altaTramite){
    Console.WriteLine("---------------------Alta Tramite--------------------------");
    EtiquetaTramite.Etiquetas etiqueta1 = EtiquetaTramite.Etiquetas.PaseAlArchivo;
    EtiquetaTramite.Etiquetas etiqueta2 = EtiquetaTramite.Etiquetas.Resolucion;
    altaTramite.Ejecutar(1, etiqueta2, "Tram01Exp01", 1);
    altaTramite.Ejecutar(1, etiqueta1, "Tram02Exp01", 1);
    altaTramite.Ejecutar(2, etiqueta1, "Tram03Exp02", 1);
    altaTramite.Ejecutar(3, etiqueta2, "Tram04Exp03", 1);
    altaTramite.Ejecutar(3, etiqueta1, "Tram05Exp03", 1);
    Console.WriteLine("Test de excepciones de validacion de expediente: ");
    altaTramite.Ejecutar(1, etiqueta2, "", 1); //Test contenido vacia
    altaTramite.Ejecutar(1, etiqueta2, null, 1); //Test contenido null
    altaTramite.Ejecutar(1, etiqueta2, " ", 1); //Test contenido con un blank
    Console.WriteLine("Test de excepciones de autorizacion: ");
    altaTramite.Ejecutar(1, etiqueta2, "TestIdUsuario0", 0);
    altaTramite.Ejecutar(1, etiqueta2, "TestIdUsuarioMayorA1", 2);
    Console.WriteLine("-----------------------------------------------------------");
}

static void TestBajaTramite(CasoDeUsoTramiteBaja bajaTramite){
    Console.WriteLine("---------------------Baja Tramite--------------------------");
    bajaTramite.Ejecutar(2, 1);
    Console.WriteLine("Test de excepciones de repositorio: ");
    bajaTramite.Ejecutar(999, 1);
    bajaTramite.Ejecutar(2, 1);
    Console.WriteLine("Test de excepciones de autorizacion: ");
    bajaTramite.Ejecutar(1, 0);
    bajaTramite.Ejecutar(1, 2);
    Console.WriteLine("-----------------------------------------------------------");
}

static void TestModificarTramite(CasoDeUsoTramiteModificacion modificarTramite){
    Console.WriteLine("---------------------Modificacion Tramite--------------------------");
    EtiquetaTramite.Etiquetas etiqueta = EtiquetaTramite.Etiquetas.PaseAEstudio;
    modificarTramite.Ejecutar(1,"TramiteModificado01",1,etiqueta);
    Console.WriteLine("Test de excepciones de validacion de expediente: ");
    modificarTramite.Ejecutar(1,"",1,etiqueta); //Test contenido vacia
    modificarTramite.Ejecutar(1,null,1,etiqueta); //Test contenido null
    modificarTramite.Ejecutar(1," ",1,etiqueta); //Test contenido con un blank
    Console.WriteLine("Test de excepciones de repositorio: ");
    modificarTramite.Ejecutar(999,"TestIdTramiteInexistente",1,etiqueta);
    modificarTramite.Ejecutar(-1,"TestIdTramiteInexistente",1,etiqueta);
    Console.WriteLine("Test de excepciones de autorizacion: ");
    modificarTramite.Ejecutar(1,"TramiteModificado01",1,etiqueta);
    modificarTramite.Ejecutar(1,"TramiteModificado01",1,etiqueta);
    Console.WriteLine("------------------------------------------------------------------");
}

static void TestConsultaTramitePorEtiqueta(CasoDeUsoTramiteConsultaPorEtiqueta consultarTramitePorEtiqueta){
    Console.WriteLine("---------------------Consultar Tramites por Etiqueta--------------------------");
    EtiquetaTramite.Etiquetas etiqueta1 = EtiquetaTramite.Etiquetas.PaseAlArchivo;
    EtiquetaTramite.Etiquetas etiqueta2 = EtiquetaTramite.Etiquetas.Despacho;
    List<Tramite>? tramites = consultarTramitePorEtiqueta.Ejecutar(etiqueta1);
    if (tramites != null)
    {
        foreach (Tramite tramite in tramites)
        {
            Console.WriteLine($"ID:{tramite.id}, Contenido:{tramite.Contenido}, Etiqueta:{tramite.Etiqueta}, Fecha de modificacion:{tramite.FechaDeModificacion}");
        }
    }
    Console.WriteLine("Test de excepciones de repositorio: ");
    List<Tramite>? tramitesNull = consultarTramitePorEtiqueta.Ejecutar(etiqueta2);
    Console.WriteLine("-----------------------------------------------------------------------------");
}
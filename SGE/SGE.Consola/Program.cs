using SGE.Aplicacion;
using SGE.Repositorios;

IExpedienteRepositorio repositorioExpedientes = new RepositorioExpedienteTXT();
//ITramiteRepositorio repositorioTramites = new RepositorioTramiteTXT();
ServicioAutorizacionProvisorio autorizacion = new ServicioAutorizacionProvisorio();

var altaExpediente = new CasoDeUsoExpedienteAlta(repositorioExpedientes, autorizacion);
var bajaExpediente = new CasoDeUsoExpedienteBaja(repositorioExpedientes, autorizacion);
var consultarExpedientePorId = new CasoDeUsoExpedienteConsultaPorId(repositorioExpedientes);
var consultarExpedienteTodos = new CasoDeUsoExpedienteConsultaTodos(repositorioExpedientes);
var modificarExpediente = new CasoDeUsoExpedienteModificacion(autorizacion, repositorioExpedientes);
// var actualizarEstado = new ServicioActualizacionEstado(repositorioExpedientes);

//Test AltaExpediente

altaExpediente.Ejecutar("Exp01", 1);
altaExpediente.Ejecutar("", 1); //excepcion de validacion de expediente
altaExpediente.Ejecutar("TestDe0", 0); //usuario no autorizado
altaExpediente.Ejecutar("TestDeMayoresA0", 2); //usuario no autorizado
altaExpediente.Ejecutar(null, 1); //excepcion de validacion de expediente


//Test BajaExpediente

bajaExpediente.Ejecutar(1, 1);//elimina al expediente con id=1
bajaExpediente.Ejecutar(999, 1);//excepcion de repositorio, el id=999 no se encuentra en el repositorio


//Test ConsultarExpedientesTodos

altaExpediente.Ejecutar("Exp02", 1);
altaExpediente.Ejecutar("Exp03", 1);
altaExpediente.Ejecutar("Exp04", 1);
List<Expediente> expedientes = consultarExpedienteTodos.Ejecutar();

foreach (Expediente ex in expedientes){
    Console.WriteLine($"Caratula:{ex.Caratula}, Estado:{ex.Estado}, Fecha de modificacion:{ex.FechaModificacion}");
}


// Test ModificarExpediente

modificarExpediente.Ejecutar(2,1,"ExpedienteModificado02");

List<Expediente>expedientes2 = consultarExpedienteTodos.Ejecutar();

foreach (Expediente ex in expedientes2){
    Console.WriteLine($"Caratula:{ex.Caratula}, Estado:{ex.Estado}, Fecha de modificacion:{ex.FechaModificacion}");
}

modificarExpediente.Ejecutar(999, 1, "TestExpedienteInexistente"); //excepcion de repositorio, el id=999 no se encuentra en el repositorio


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

/*
actualizarEstado.ModificarExpediente(3, etiqueta1); //respuesta esperada ConResolucion
actualizarEstado.ModificarExpediente(1, etiqueta2); //El estado se mantiene igual
*/
using SGE.Aplicacion;
using SGE.Repositorios;

IExpedienteRepositorio repositorioExpedientes = new RepositorioExpedienteTXT();
//ITramiteRepositorio repositorioTramites = new RepositorioTramiteTXT();
ServicioAutorizacionProvisorio autorizacion = new ServicioAutorizacionProvisorio();

var altaExpediente = new CasoDeUsoExpedienteAlta(repositorioExpedientes, autorizacion);
var bajaExpediente = new CasoDeUsoExpedienteBaja(repositorioExpedientes, autorizacion);
var listarExpedientePorId = new CasoDeUsoExpedienteConsultaPorId(repositorioExpedientes);
var listarExpedienteTodos = new CasoDeUsoExpedienteConsultaTodos(repositorioExpedientes);
var modificarExpediente = new CasoDeUsoExpedienteModificacion(autorizacion, repositorioExpedientes);
// var actualizarEstado = new ServicioActualizacionEstado(repositorioExpedientes);
/*
EtiquetaTramite.Etiquetas etiqueta1 = EtiquetaTramite.Etiquetas.Resolucion;
EtiquetaTramite.Etiquetas etiqueta2 = EtiquetaTramite.Etiquetas.Despacho;
*/

/*
altaExpediente.Ejecutar("Exp01", 1);
altaExpediente.Ejecutar("TestDe0", 0);
altaExpediente.Ejecutar("TestDeMayoresA0", 2);
altaExpediente.Ejecutar("Exp02", 1);
*/

/*
bajaExpediente.Ejecutar(2, 1);
*/

/*
List<Expediente> expedientes = listarExpedienteTodos.Ejecutar();

foreach (Expediente ex in expedientes){
    Console.WriteLine(ex.Caratula);
}

modificarExpediente.Ejecutar(1,1,"ExpedienteModificado01");

expedientes = listarExpedienteTodos.Ejecutar();

foreach (Expediente ex in expedientes){
    Console.WriteLine(ex.Caratula);
}
*/

/*
ConsultaExpediente? consul = listarExpedientePorId.Ejecutar(1);
Console.WriteLine(consul.Expediente.Caratula);
*/

/*
actualizarEstado.ModificarExpediente(3, etiqueta1); //respuesta esperada ConResolucion
actualizarEstado.ModificarExpediente(1, etiqueta2); //El estado se mantiene igual
*/
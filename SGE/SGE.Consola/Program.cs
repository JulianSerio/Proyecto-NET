using SGE.Aplicacion;
using SGE.Repositorios;

GestionSqlite.Inicializar();

//RepositorioTramiteSQLite.Inicializar();
using (var context = new RepositorioContext())
{
    Console.WriteLine("-- Tabla Usuarios --");
    foreach (var us in context.Usuarios)
    {
      Console.WriteLine($"{us.IdUsuario} {us.Nombre} {us.Apellido}");
    }
    Console.WriteLine("-- Tabla Expedientes --");
    foreach (var ex in context.Expedientes)
    {
      Console.WriteLine($"{ex.Id} {ex.Caratula} {ex.Estado}");
    }
    Console.WriteLine("-- Tabla Tramites --");
    foreach (var tr in context.Tramites)
    {
      Console.WriteLine($"{tr.Id} {tr.Contenido} {tr.EtiquetaTramite}");
    }
}

//Repositorios
IExpedienteRepositorio repositorioExpedientes = new RepositorioExpedienteSQLite();
ITramiteRepositorio repositorioTramites = new RepositorioTramiteSQLite();
IUsuarioRepositorio repositorioUsuarios = new RepositorioUsuarioSQLite();

//Servicios
ServicioAutorizacion autorizacion = new ServicioAutorizacion(repositorioUsuarios);
ServicioActualizacionEstado actualizacion = new ServicioActualizacionEstado(repositorioExpedientes, repositorioTramites);
UsuarioValidador usuarioValidador = new UsuarioValidador(repositorioUsuarios);

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

var altaUsuario = new CasoDeUsoUsuarioAlta(repositorioUsuarios, usuarioValidador);

altaUsuario.Ejecutar("pepe", "lopez", "emial@gmail.com", "pepe1020");

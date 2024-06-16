using SGE.Aplicacion;
using SGE.Repositorios;

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
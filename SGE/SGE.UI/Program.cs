using SGE.UI.Components;
using SGE.Repositorios;
using SGE.Aplicacion;

var builder = WebApplication.CreateBuilder(args);

//Servicios de Blazor
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddServerSideBlazor();

//Repositorio
builder.Services.AddSingleton<IExpedienteRepositorio,RepositorioExpedienteSQLite>();
builder.Services.AddSingleton<ITramiteRepositorio,RepositorioTramiteSQLite>();
builder.Services.AddSingleton<IUsuarioRepositorio,RepositorioUsuarioSQLite>();

//CU Expediente
builder.Services.AddTransient<CasoDeUsoExpedienteAlta>(sp =>{
    var expedienteRepositorio = sp.GetRequiredService<IExpedienteRepositorio>();
    var autorizacionServicio = sp.GetRequiredService<ServicioAutorizacion>();
    return new CasoDeUsoExpedienteAlta(expedienteRepositorio, autorizacionServicio);
});
builder.Services.AddTransient<CasoDeUsoExpedienteBaja>(sp =>{
    var expedienteRepositorio = sp.GetRequiredService<IExpedienteRepositorio>();
    var autorizacionServicio = sp.GetRequiredService<ServicioAutorizacion>();
    return new CasoDeUsoExpedienteBaja(expedienteRepositorio, autorizacionServicio);
});
builder.Services.AddTransient<CasoDeUsoExpedienteModificacion>(sp =>{
    var expedienteRepositorio = sp.GetRequiredService<IExpedienteRepositorio>();
    var autorizacionServicio = sp.GetRequiredService<ServicioAutorizacion>();
    return new CasoDeUsoExpedienteModificacion(autorizacionServicio,expedienteRepositorio);
});
builder.Services.AddTransient<CasoDeUsoExpedienteConsultaPorId>(sp =>{
    var expedienteRepositorio = sp.GetRequiredService<IExpedienteRepositorio>();
    return new CasoDeUsoExpedienteConsultaPorId(expedienteRepositorio);
});
builder.Services.AddTransient<CasoDeUsoExpedienteConsultaTodos>(sp =>{
    var expedienteRepositorio = sp.GetRequiredService<IExpedienteRepositorio>();
    return new CasoDeUsoExpedienteConsultaTodos(expedienteRepositorio);
});

//CU Tramite
builder.Services.AddTransient<CasoDeUsoTramiteAlta>(sp =>{
    var tramiteRepositorio = sp.GetRequiredService<ITramiteRepositorio>();
    var autorizacionServicio = sp.GetRequiredService<ServicioAutorizacion>();
    var actualizacion = sp.GetRequiredService<ServicioActualizacionEstado>();
    return new CasoDeUsoTramiteAlta(tramiteRepositorio, autorizacionServicio,actualizacion);
});
builder.Services.AddTransient<CasoDeUsoTramiteBaja>(sp =>{
    var tramiteRepositorio = sp.GetRequiredService<ITramiteRepositorio>();
    var autorizacionServicio = sp.GetRequiredService<ServicioAutorizacion>();
    var actualizacion = sp.GetRequiredService<ServicioActualizacionEstado>();
    return new CasoDeUsoTramiteBaja(tramiteRepositorio, autorizacionServicio, actualizacion);
});
builder.Services.AddTransient<CasoDeUsoTramiteModificacion>(sp =>{
    var tramiteRepositorio = sp.GetRequiredService<ITramiteRepositorio>();
    var autorizacionServicio = sp.GetRequiredService<ServicioAutorizacion>();
    var actualizacion = sp.GetRequiredService<ServicioActualizacionEstado>();
    return new CasoDeUsoTramiteModificacion(tramiteRepositorio, autorizacionServicio, actualizacion);
});
builder.Services.AddTransient<CasoDeUsoTramiteConsultaPorEtiqueta>(sp =>{
    var tramiteRepositorio = sp.GetRequiredService<ITramiteRepositorio>();
    return new CasoDeUsoTramiteConsultaPorEtiqueta(tramiteRepositorio);
});
builder.Services.AddTransient<CasoDeUsoTramiteConsultaTodos>(sp =>{
    var tramiteRepositorio = sp.GetRequiredService<ITramiteRepositorio>();
    return new CasoDeUsoTramiteConsultaTodos(tramiteRepositorio);
});

//CU Usuario
builder.Services.AddTransient<CasoDeUsoUsuarioAlta>(sp =>{
    var repoUsuarios = sp.GetRequiredService<IUsuarioRepositorio>();
    var validador = sp.GetRequiredService<UsuarioValidador>();
    var autorizacionServicio = sp.GetRequiredService<ServicioAutorizacion>();
    return new CasoDeUsoUsuarioAlta(repoUsuarios, validador, autorizacionServicio);
});
builder.Services.AddTransient<CasoDeUsoUsuarioBaja>(sp =>{
    var repoUsuarios = sp.GetRequiredService<IUsuarioRepositorio>();
    return new CasoDeUsoUsuarioBaja(repoUsuarios);
});
builder.Services.AddTransient<CasoDeUsoUsuarioModificacion>(sp =>{
    var repoUsuarios = sp.GetRequiredService<IUsuarioRepositorio>();
    var validador = sp.GetRequiredService<UsuarioValidador>();
    return new CasoDeUsoUsuarioModificacion(repoUsuarios, validador);
});
builder.Services.AddTransient<CasoDeUsoUsuarioConsultaPorId>(sp =>{
    var repoUsuarios = sp.GetRequiredService<IUsuarioRepositorio>();
    return new CasoDeUsoUsuarioConsultaPorId(repoUsuarios);
});
builder.Services.AddTransient<CasoDeUsoUsuarioConsultaTodos>(sp =>{
    var repoUsuarios = sp.GetRequiredService<IUsuarioRepositorio>();
    return new CasoDeUsoUsuarioConsultaTodos(repoUsuarios);
});
builder.Services.AddTransient<CasoDeUsoUsuarioIniciarSesion>(sp =>{
    var repoUsuarios = sp.GetRequiredService<IUsuarioRepositorio>();
    return new CasoDeUsoUsuarioIniciarSesion(repoUsuarios);
});

//Servicios
builder.Services.AddTransient<IServicioAutorizacion>(servi =>{
    var repoUsuarios = servi.GetRequiredService<IUsuarioRepositorio>();
    return new ServicioAutorizacion(repoUsuarios);
});
builder.Services.AddTransient<UsuarioValidador>(servi =>{
    var repoUsuarios = servi.GetRequiredService<IUsuarioRepositorio>();
    return new UsuarioValidador(repoUsuarios);
});
builder.Services.AddTransient<ServicioActualizacionEstado>(servi =>{
    var repoTramites = servi.GetRequiredService<ITramiteRepositorio>();
    var repoExpedientes = servi.GetRequiredService<IExpedienteRepositorio>();
    return new ServicioActualizacionEstado(repoExpedientes,repoTramites);
});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

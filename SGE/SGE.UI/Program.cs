using SGE.UI.Components;
using SGE.Repositorios;
using SGE.Aplicacion;

var builder = WebApplication.CreateBuilder(args);
/*
//Gestor 
RepositorioContext context = new RepositorioContext();

//Repositorio
builder.Services.AddSingleton<IExpedienteRepositorio,IExpedienteRepositorio>();
builder.Services.AddSingleton<ITramiteRepositorio,ITramiteRepositorio>();
builder.Services.AddSingleton<IUsuarioRepositorio,IUsuarioRepositorio>();

//CU Expediente
builder.Services.AddTransient<CasoDeUsoExpedienteAlta>();
builder.Services.AddTransient<CasoDeUsoExpedienteBaja>();
builder.Services.AddTransient<CasoDeUsoExpedienteConsultaPorId>();
builder.Services.AddTransient<CasoDeUsoExpedienteConsultaTodos>();
builder.Services.AddTransient<CasoDeUsoExpedienteModificacion>();

//CU Tramite
builder.Services.AddTransient<CasoDeUsoTramiteAlta>();
builder.Services.AddTransient<CasoDeUsoTramiteBaja>();
builder.Services.AddTransient<CasoDeUsoTramiteConsultaPorEtiqueta>();
builder.Services.AddTransient<CasoDeUsoTramiteConsultaTodos>();
builder.Services.AddTransient<CasoDeUsoTramiteModificacion>();

//CU Usuario
builder.Services.AddTransient<CasoDeUsoUsuarioAlta>();
builder.Services.AddTransient<CasoDeUsoUsuarioBaja>();
builder.Services.AddTransient<CasoDeUsoUsuarioConsultaPorId>();
builder.Services.AddTransient<CasoDeUsoUsuarioConsultaTodos>();
builder.Services.AddTransient<CasoDeUsoUsuarioIniciarSesion>();
builder.Services.AddTransient<CasoDeUsoUsuarioModificacion>();

//Servicios
builder.Services.AddTransient<ServicioAutorizacion>();
builder.Services.AddTransient<UsuarioValidador>();

*/
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddServerSideBlazor();
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

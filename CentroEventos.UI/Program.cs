using CentroEventos.Aplicacion.Repositorios;
using CentroEventos.Aplicaciones.Validaciones;
using CentroEventos.UI.Components;
using CentroEventos.UI.Components.Pages;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//base de datos
builder.Services.AddDbContext<CentroEventosContext>();
CentroEventosSQLite.Inicializar();


//servicio de autorizacion
builder.Services.AddScoped<ISesion,ServicioSesion>();
builder.Services.AddSingleton<IServicioAutorizacion, ServicioAutorizacion>();
builder.Services.AddTransient<LoginUseCase>();
    
//modicacion
builder.Services.AddTransient<ModificarPersonaUseCase>();
builder.Services.AddTransient<ModificarEventoUseCase>();
builder.Services.AddTransient<ModificarReservaUseCase>();
builder.Services.AddTransient<ModificarUsuarioUseCase>();


//Listados
builder.Services.AddTransient<ListarUsuariosUseCase>();
builder.Services.AddTransient<ListarPersonasUseCase>();
builder.Services.AddTransient<ListarEventosUseCase>();
builder.Services.AddTransient<ListarReservaUseCase>();
builder.Services.AddTransient<ListarEventosConCupoDisponibleUseCase>();
builder.Services.AddTransient<ListarAsistenciaAEventoUseCase>();


//altas
builder.Services.AddTransient<AltaUsuarioUseCase>();
builder.Services.AddTransient<AltaEventoUseCase>();
builder.Services.AddTransient<AltaReservaUseCase>();
builder.Services.AddTransient<AltaPersonaUseCase>();
builder.Services.AddTransient<AsignarPermisosUseCase>();


//baja
builder.Services.AddTransient<BajaUsuarioUseCase>();
builder.Services.AddTransient<BajaReservaUseCase>();
builder.Services.AddTransient<BajaPersonaUseCase>();
builder.Services.AddTransient<BajaEventoUseCase>();



//validadores
builder.Services.AddTransient<ValidarUsuario>();
builder.Services.AddTransient<ValidarEvento>();
builder.Services.AddTransient<ValidarPersona>();
builder.Services.AddTransient<ValidarReserva>();

//repositorios
builder.Services.AddScoped<IRepositorioEventoDeportivo, RepositorioEventoDeportivo>();
builder.Services.AddScoped<IRepositorioReserva, RepositorioReserva>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<IRepositorioPersona, RepositorioPersona>();







builder.Services.AddBlazorBootstrap();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

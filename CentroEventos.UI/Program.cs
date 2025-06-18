using CentroEventos.Aplicacion.Repositorios;
using CentroEventos.Aplicaciones.Validaciones;
using CentroEventos.UI.Components;
  
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<CentroEventosContext>();
CentroEventosSQLite.Inicializar();

builder.Services.AddTransient<AltaPersonaUseCase>();
builder.Services.AddTransient<ValidarPersona>();
builder.Services.AddTransient<ListarPersonasUseCase>();

builder.Services.AddTransient<AltaUsuarioUseCase>();
builder.Services.AddTransient<ValidarUsuario>();


builder.Services.AddScoped<IRepositorioEventoDeportivo, RepositorioEventoDeportivo>();
builder.Services.AddScoped<IRepositorioReserva, RepositorioReserva>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<IRepositorioPersona, RepositorioPersona>();
builder.Services.AddSingleton<IServicioAutorizacion, ServicioAutorizacion>();


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

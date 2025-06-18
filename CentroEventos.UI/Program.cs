using CentroEventos.Aplicacion.Repositorios;
using CentroEventos.Aplicaciones.Validaciones;
using CentroEventos.UI.Components;
  
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<CentroEventosContext>();
CentroEventosSQLite.Inicializar();

<<<<<<< HEAD

//servicio de autorizacion
builder.Services.AddTransient<LoginUseCase>();
builder.Services.AddSingleton<IServicioAutorizacion, ServicioAutorizacion>();


=======
builder.Services.AddTransient<AltaPersonaUseCase>();
builder.Services.AddTransient<ValidarPersona>();
>>>>>>> 8f0e0fa27f29b9b90f5e6074711dc56f81e17fc2
builder.Services.AddTransient<ListarPersonasUseCase>();
<<<<<<< HEAD
builder.Services.AddTransient<ListarEventosUseCase>();
builder.Services.AddTransient<ListarReservaUseCase>();
builder.Services.AddTransient<ValidarUsuario>();
=======

>>>>>>> 49648da3f55be7d28174b97527188119871bf65b
builder.Services.AddTransient<AltaUsuarioUseCase>();
builder.Services.AddTransient<ValidarUsuario>();





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

using CentroEventos.Aplicaciones.Excepciones;

IRepositorioPersona repoPersona= new RepositorioPersona();
IServicioAutorizacion servicioAutorizacion = new ServicioAutorizacionProvisorio();
IRepositorioEventoDeportivo repoEvento = new RepositorioEventoDeportivo();
IRepositorioReserva repoReserva = new RepositorioReserva();

AltaPersonaUseCase altaPersona = new AltaPersonaUseCase(repoPersona, servicioAutorizacion);
ModificarPersonaUseCase modPersona = new ModificarPersonaUseCase(repoPersona, servicioAutorizacion);
BajaPersonaUseCase bajaPersona = new BajaPersonaUseCase(repoPersona, servicioAutorizacion);

AltaEventoUseCase altaEvento = new AltaEventoUseCase(repoEvento, repoPersona, servicioAutorizacion);
ModificarEventoUseCase modEvento = new ModificarEventoUseCase(repoEvento,repoPersona,servicioAutorizacion);
BajaEventoUseCase bajaEvento = new BajaEventoUseCase(repoEvento, repoPersona, servicioAutorizacion);


altaPersona.Ejecutar(new Persona("1235643", "pablo", "isla", "chi12cho@gmail", "02213454"), 1);
modPersona.Ejecutar(new Persona("1235643", "pablo", "cabe", "pablocabe@gmail", "02213454"), 1);
bajaPersona.Ejecutar(1, 1);

altaEvento.Ejecutar(new EventoDeportivo("futbol","futbol 5", new DateTime(2025, 5, 23, 19, 0, 0), 2, 10, 2), 1);
modEvento.Ejecutar(new EventoDeportivo("futbol", "futbol 5", new DateTime(2025, 6, 23, 19, 0, 0), 2, 10, 2), 1);
bajaEvento.Ejecutar(repoReserva, 12, 1);

ListarPersonasUseCase listarPersonas = new ListarPersonasUseCase(repoPersona);
ListarEventosUseCase listarEventos = new ListarEventosUseCase(repoEvento);
ListarReservaUseCase listarReservas = new ListarReservaUseCase(repoReserva);

Console.WriteLine("Personas:"+"\n");
listarPersonas.Ejecutar();
Console.WriteLine();
Console.WriteLine("Eventos:"+"\n");
listarEventos.Ejecutar();
Console.WriteLine();
Console.WriteLine("Reservas:"+"\n");
listarReservas.Ejecutar();

ListarEventosConCupoDisponibleUseCase listarEventosConCupo = new ListarEventosConCupoDisponibleUseCase(repoEvento, repoReserva);
List<EventoDeportivo> eventosDisponibles = listarEventosConCupo.Ejecutar();

Console.WriteLine("Eventos con cupo disponible:\n");
foreach (EventoDeportivo evento in eventosDisponibles)
{
    Console.WriteLine(evento.ToString() + "\n");
}

//ESTO ME GENERA DUDA, porque la lista de asistencvia puede arrojar una lista o un error :)

ListarAsistenciaAEventoUseCase listarAsistencia = new ListarAsistenciaAEventoUseCase(repoEvento, repoReserva);

try
{
    List<Reserva> asistentes = listarAsistencia.Ejecutar(1);
    Console.WriteLine("Asistentes al evento:"+"\n");

    foreach (Reserva r in asistentes)
    {
        Console.WriteLine(r.ToString() + "\n");
    }
}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex.Message);
}

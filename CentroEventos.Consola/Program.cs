using CentroEventos.Aplicaciones.Excepciones;

IRepositorioPersona repoPersona = new RepositorioPersona();
IRepositorioEventoDeportivo repoEvento = new RepositorioEventoDeportivo();
IRepositorioReserva repoReserva = new RepositorioReserva();
IServicioAutorizacion servicioAutorizacion = new ServicioAutorizacionProvisorio();

AltaPersonaUseCase altaPersona = new AltaPersonaUseCase(repoPersona, servicioAutorizacion);
ModificarPersonaUseCase modPersona = new ModificarPersonaUseCase(repoPersona, servicioAutorizacion);
BajaPersonaUseCase bajaPersona = new BajaPersonaUseCase(repoPersona,repoEvento,repoReserva, servicioAutorizacion);

AltaEventoUseCase altaEvento = new AltaEventoUseCase(repoEvento, repoPersona, servicioAutorizacion);
ModificarEventoUseCase modEvento = new ModificarEventoUseCase(repoEvento,repoPersona,servicioAutorizacion);
BajaEventoUseCase bajaEvento = new BajaEventoUseCase(repoEvento, repoPersona, servicioAutorizacion);

AltaReservaUseCase altaReserva = new AltaReservaUseCase(repoReserva, repoPersona, repoEvento, servicioAutorizacion);
ModificarReservaUseCase modReserva = new ModificarReservaUseCase(repoReserva, repoPersona, repoEvento, servicioAutorizacion);
BajaReservaUseCase bajaReserva = new BajaReservaUseCase(repoReserva, repoPersona, repoEvento, servicioAutorizacion);

ListarPersonasUseCase listarPersonas = new ListarPersonasUseCase(repoPersona);
ListarEventosUseCase listarEventos = new ListarEventosUseCase(repoEvento);
ListarReservaUseCase listarReservas = new ListarReservaUseCase(repoReserva);

ListarAsistenciaAEventoUseCase listarAsistencia = new ListarAsistenciaAEventoUseCase(repoEvento, repoReserva, repoPersona);
ListarEventosConCupoDisponibleUseCase listarEventosConCupo = new ListarEventosConCupoDisponibleUseCase(repoEvento, repoReserva);


try
{
    CargarPersonas();
    modPersona.Ejecutar(new Persona("9876543", "Juan", "Perez", "juan.perez@gmail.com", "01122334455"), 1);
    bajaPersona.Ejecutar(5, 1);
    ListadoPersona();

    CargarEventos();
    modEvento.Ejecutar(new EventoDeportivo("Futbol", "Final de la copa interfacultades", DateTime.Now.AddSeconds(1), 10, 22, 1), 1);
    bajaEvento.Ejecutar(repoReserva, 4, 1);
    ListadoEvento();

    CargarReservas();
    modReserva.Ejecutar(new Reserva(1, 1, DateTime.Now, EstadosAsistencia.Presente), 1);
    bajaReserva.Ejecutar(4, 1);
    ListadoReservas();

    ListadoEventosDisponibles();
    ListarPersonasAsistidas(1);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}


void CargarPersonas()
{
    altaPersona.Ejecutar(new Persona("9876543", "Juan", "Perez", "juan.perez@example.com", "01122334455"), 1);
    altaPersona.Ejecutar(new Persona("8765432", "Maria", "Gomez", "maria.gomez@example.com", "02299887766"), 1);
    altaPersona.Ejecutar(new Persona("7654321", "Carlos", "Rodriguez", "carlos.rodriguez@example.com", "03311223344"), 1);
    altaPersona.Ejecutar(new Persona("6543210", "Laura", "Fernandez", "laura.fernandez@example.com", "04455667788"), 1);
    altaPersona.Ejecutar(new Persona("5432109", "Sofia", "Martinez", "sofia.martinez@example.com", "05566778899"), 1);
}


void CargarEventos()
{
    altaEvento.Ejecutar(new EventoDeportivo("Futbol", "Final copa interfacultades", new DateTime(2025, 8, 25, 12, 0, 0), 6,3, 1), 1);
    altaEvento.Ejecutar(new EventoDeportivo("Voley", "UNLP vs UBA", new DateTime(2025, 11, 7, 21, 0, 0), 3, 2, 4), 1);
    altaEvento.Ejecutar(new EventoDeportivo("Ping Pong", "Demostracion a beneficio", new DateTime(2025, 6, 29, 16, 0, 0), 6, 2, 2), 1);
    altaEvento.Ejecutar(new EventoDeportivo("Tiro con arco", "Fecha 1", new DateTime(2025, 10, 1, 8, 0, 0), 4, 4, 3), 1);
}


void CargarReservas()
{
    altaReserva.Ejecutar(new Reserva(1, 1, DateTime.Now, EstadosAsistencia.Pendiente),1);
    altaReserva.Ejecutar(new Reserva(2, 1, DateTime.Now, EstadosAsistencia.Pendiente),1);
    altaReserva.Ejecutar(new Reserva(3, 1, DateTime.Now, EstadosAsistencia.Pendiente),1);
    altaReserva.Ejecutar(new Reserva(1, 2, DateTime.Now, EstadosAsistencia.Pendiente),1);
}


void ListadoPersona()
{
    Console.WriteLine("-----------Personas-----------" + "\n");
    List<Persona> personas = listarPersonas.Ejecutar();
    if (personas != null)
    {
        foreach (Persona p in personas)
        {
            Console.WriteLine(p.ToString().Replace("#", " "));
        }
    }
    else
    { 
        Console.WriteLine("No hay personas cargadas");
    }
}


void ListadoEvento()
{
    Console.WriteLine("-----------Eventos-----------" + "\n");
    List<EventoDeportivo> todosEventos = listarEventos.Ejecutar();
    if (todosEventos != null)
    {
        foreach (EventoDeportivo e in todosEventos)
        {
            Console.WriteLine(e.ToString().Replace("#", " "));
        }
    }
    else
    {
        Console.WriteLine("No hay eventos cargadas");
    }
   
}


void ListadoReservas()
{
    Console.WriteLine("-----------Reservas-----------" + "\n");
    List<Reserva> todasReservas = listarReservas.Ejecutar();
    if (todasReservas != null)
    {
        foreach (Reserva r in todasReservas)
        {
            Console.WriteLine(r.ToString().Replace("#", " "));
        }
    }
    else
    {
        Console.WriteLine("No hay reservas cargadas");
    }
}


void ListadoEventosDisponibles()
{
    List<EventoDeportivo> eventosDisponibles = listarEventosConCupo.Ejecutar();
    Console.WriteLine("-----------Eventos con cupo disponibles-----------" + "\n");
    if (eventosDisponibles != null)
    {
        foreach (EventoDeportivo e in eventosDisponibles)
        {
            Console.WriteLine(e.ToString().Replace("#", " "));
        }
    }
    else
    { 
        Console.WriteLine("No existen eventos con cupos disponibles");
    }
}


void ListarPersonasAsistidas(int idEvento)
{
    Console.WriteLine($"-----------Personas asistidas al evento {idEvento}-----------" + "\n");
    List<Persona> AsistenciaAEvento = listarAsistencia.Ejecutar(idEvento);
    if (AsistenciaAEvento != null)
    {
        foreach (Persona p in AsistenciaAEvento)
        {
            Console.WriteLine(p.ToString().Replace("#", " "));
        }
    }
    else
    { 
        Console.WriteLine("El evento no tiene  parcticiapantes");
    }
}

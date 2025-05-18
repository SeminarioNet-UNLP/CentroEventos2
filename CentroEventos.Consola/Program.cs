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



//altaPersona.Ejecutar(new Persona("1235643", "pablo", "isla", "chi12cho@gmail", "02213454"), 1);
//modPersona.Ejecutar(new Persona("1235643", "pablo", "cabe", "pablocabe@gmail", "02213454"), 1);
//bajaPersona.Ejecutar(1, 1);


altaEvento.Ejecutar(new EventoDeportivo("futbol","futbol 5", new DateTime(2025, 5, 23, 19, 0, 0), 2, 10, 2), 1);
modEvento.Ejecutar(new EventoDeportivo("futbol", "futbol 5", new DateTime(2025, 6, 23, 19, 0, 0), 2, 10, 2), 1);
bajaEvento.Ejecutar(repoReserva,12,1);










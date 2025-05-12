IRepositorioPersona repoPersona= new RepositorioPersona();
IServicioAutorizacion servicioAutorizacion= new ServicioAutorizacionProvisorio();
AltaPersonaUseCase altaPersona = new AltaPersonaUseCase(repoPersona,servicioAutorizacion);
altaPersona.Ejecutar(new Persona("1234", "federico", "isla", "fede@gmail", "02213454"), 1);

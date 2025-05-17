IRepositorioPersona repoPersona= new RepositorioPersona();
IServicioAutorizacion servicioAutorizacion= new ServicioAutorizacionProvisorio();
AltaPersonaUseCase altaPersona = new AltaPersonaUseCase(repoPersona, servicioAutorizacion);
ModificarPersonaUseCase modPersona = new ModificarPersonaUseCase(repoPersona, servicioAutorizacion);
BajaPersonaUseCase bajaPersona = new BajaPersonaUseCase(repoPersona, servicioAutorizacion);
//altaPersona.Ejecutar(new Persona("1235643", "pablo", "isla", "chi12cho@gmail", "02213454"), 1);
modPersona.Ejecutar(new Persona("1235643", "pablo", "cabe", "pablocabe@gmail", "02213454"), 1);
bajaPersona.Ejecutar(1, 1);





IRepositorioPersona repoPersona= new RepositorioPersona();
AltaPersonaUseCase altaPersona = new AltaPersonaUseCase(repoPersona);
altaPersona.Ejecutar(new Persona("1234", "federico", "isla", "fede@gmail", "02213454"));

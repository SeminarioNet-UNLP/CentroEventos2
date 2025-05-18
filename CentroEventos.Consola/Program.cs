IRepositorioPersona repoPersona= new RepositorioPersona();
IServicioAutorizacion servicioAutorizacion= new ServicioAutorizacionProvisorio();
AltaPersonaUseCase altaPersona = new AltaPersonaUseCase(repoPersona, servicioAutorizacion);
ModificarPersonaUseCase modPersona = new ModificarPersonaUseCase(repoPersona, servicioAutorizacion);
BajaPersonaUseCase bajaPersona = new BajaPersonaUseCase(repoPersona, servicioAutorizacion);
//altaPersona.Ejecutar(new Persona("1235643", "pablo", "isla", "chi12cho@gmail", "02213454"), 1);
//modPersona.Ejecutar(new Persona("1235643", "pablo", "cabe", "pablocabe@gmail", "02213454"), 1);
//bajaPersona.Ejecutar(1, 1);

IRepositorioEventoDeportivo repoEvento = new RepositorioEventoDeportivo();
IServicioAutorizacion servicioAutorizacion1 = new ServicioAutorizacionProvisorio();
AltaEventoUseCase altaEvento = new AltaEventoUseCase(repoEvento, repoPersona, servicioAutorizacion1);
ModificarEventoUseCase modEvento = new ModificarEventoUseCase(repoEvento,repoPersona,servicioAutorizacion1);
BajaEventoUseCase bajaEvento = new BajaEventoUseCase(repoEvento, repoPersona, servicioAutorizacion1);

altaEvento.Ejecutar(new EventoDeportivo("Futbol", "Torneo futbol 5", new DateTime(2002, 5, 11), 7, 4, 1), 1);
//este me tira que la fecha es menor y el id no corresponde a nadie.

EventoDeportivo evento1 = new EventoDeportivo("Futbol", "Torneo futbol 5", new DateTime(2002, 6, 11), -5, -1, 1);
evento1.Id = 1; //id asi cumple boolElPermiso
bajaEvento.Ejecutar(evento1, 1);
//Este me tira todos los errores que tiene (fecha, cupo, horas y id no pertenece). Tuve que cambiar
//los casos uso de evento y crear una lista con errores. Solo asi me tiraba todos los errores q tiene y no solo el primero que consigue.


//modEvento.Ejecutar(new EventoDeportivo("Futbol", "Torneo futbol 5", new DateTime(2002, 5, 11), 7, 4, 3), 1);
//Aca necesito usar el altapersona, pero al habilitarlo, me tira Error: el archivo no existe. Por las dudas no lo toco por ahora.
//Tendria que tirarme Error el id no corresponde, pues la persona tiene id=1, y ahi le dije id=3 al modevento.


//El problema es que solamente imprime el primer evento. En este caso solo imprime el que tiene error en fecha y id,
//pero no imprime el bajaEvento con sus 4 errores. Si pongo primero el bajaEvento solo imprime ese e ignora el otro.





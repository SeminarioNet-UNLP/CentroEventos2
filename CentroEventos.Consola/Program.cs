//test para cargar un estudiante
using CentroEventos.Aplicacion;
IPersonaRepositorio repositorio =new RepositorioEstudiante();
EstudianteAltaCDU cduEstu = new(repositorio);

cduEstu.Ejecutar(new Estudiante(1,123,"federico","isla", "la plata","informatica","122345678","fede@",26078,"Lic.informatica" ));

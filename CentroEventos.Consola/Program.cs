//test para cargar un estudiante
using CentroEventos.Aplicacion;
IPersonaRepositorio repositorioE = new RepositorioEstudiante();
EstudianteAltaCDU cduEstu = new(repositorioE);

cduEstu.Ejecutar(new Estudiante(1,123,"federico","isla", "la plata","informatica","122345678","fede@",26078,"Lic.informatica" ));

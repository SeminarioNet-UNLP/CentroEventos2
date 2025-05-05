using CentroEventos.Aplicacion;

public interface IActividadAlta {
  void DarActividadAlta (ActividadDeportiva actividad);
}

public interface IActividadModificacion {
  void ModificarActividad (ActividadDeportiva actividad);
}

public interface IActividadBaja {
  void DarActividadDeBaja (ActividadDeportiva actividad);
}
public interface IDeporteAlta {
    void DarDeporteAlta (Deporte deporte);
}

public interface IDeporteModificacion {
  void ModificarDeporte (Deporte deporte);
}

public interface IDeporteBaja {
  void DarDeporteDeBaja(Deporte deporte);
}

public interface IInscripcionAlta{
  void InscribirAlumno (Estudiante estudiante, ActividadDeportiva actividad);
}

public interface IInscripcionModificacion {
  void ModificarInscripcion (Estudiante estudiante, ActividadDeportiva actividad);
}

public interface IInscripcionBaja{
  void DarEstudianteDeBaja (Estudiante estudiante, ActividadDeportiva actividad);
}

public interface IUsuarioAlta {
  void DarUsuarioDeAlta (Usuario usuario); 
}

public interface IUsuarioModificacion{
  void ModificarUsuario (Usuario usuario);
}

public interface IUsuarioBaja{
  void DarUsuarioDeBaja (Usuario usuario);
}


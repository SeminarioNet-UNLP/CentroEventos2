public interface IActividadRepositorio {
  public void CrearActividad (ActividadDeportiva actividad);

  public void EliminarActividad (int id);

  public void ModificarActividad (ActividadDeportiva actividad);
  public List <ActividadDeportiva> listarTodos ();

  // List <ActividadDeportiva> listaNueva = sjajhjd.listarTodos()
}
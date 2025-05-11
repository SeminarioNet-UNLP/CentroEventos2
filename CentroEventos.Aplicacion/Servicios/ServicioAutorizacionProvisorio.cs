public class ServicioAutorizacionProvisorio : IServicioAutorizacion
{
    public bool PoseeElPermiso(int IdUsuario, Permiso permiso)
    {
        return IdUsuario == 1;
    }
}

/*
Para esta primera entrega, se desarrollará una implementación provisional del servicio de autorización
llamada ServicioAutorizacionProvisorio.
Este servicio responderá de la siguiente manera:
● Si IdUsuario == 1, devuelve true para cualquier permiso solicitado.
● Si el IdUsuario es distinto de 1, devuelve false para todos los permisos.
*/
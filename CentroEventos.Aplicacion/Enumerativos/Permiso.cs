/*
Implementar el tipo enumerativo Permiso que se utilizará para gestionar la autorización de los usuarios en
el sistema. Cada usuario del sistema podrá poseer uno o varios de los siguientes permisos, que
habilitan acciones específicas sobre las entidades del sistema:
*/

public enum Permiso {
    EventoAlta,
    EventoModificacion,
    EventoBaja,
    ReservaAlta,
    ReservaModificacion,
    ReservaBaja,
    UsuarioAlta,
    UsuarioModificacion,
    UsuarioBaja
}

/*
Se asume que todos los usuarios tendrán derecho de lectura en relación a todas las entidades.
Por lo tanto no se requerirá gestionar la autorización para la generación de listados
*/
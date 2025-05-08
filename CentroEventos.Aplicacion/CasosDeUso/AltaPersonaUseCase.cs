public class AltaPersonaUseCase(IRepositorioPersona repo)
{
    private readonly IRepositorioPersona Repo = repo;

    public void Ejecutar(Persona persona)
    {
        Repo.AltaPersona(persona);
    }
}

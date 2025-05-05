public abstract class PersonaCDU
{
    protected IPersonaRepositorio repositorio {get; set;}
    protected PersonaCDU(IPersonaRepositorio Repositorio)=> repositorio = Repositorio;
}
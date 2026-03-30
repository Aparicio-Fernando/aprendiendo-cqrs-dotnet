namespace TiendaAPI.Interfaces
{
    public interface ICommandHandler<TCommand>
    {
        Task<string> Handle(TCommand command);
    }
}

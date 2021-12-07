using System.Threading.Tasks;

namespace NotificationSchedulingSystem.Shared.Commands
{
    public interface ICommandDispatcher
    {
        Task DispatchAsync<TCommand>(TCommand command) where TCommand : class, ICommand;
    }
}

using System.Threading.Tasks;

namespace Domainatr.Messaging.Core.Commands
{
    public interface ICommandHandler<in TCommand>
        where TCommand : class, ICommand
    {
        Task<CommandExecutionResult> HandlerAsync(TCommand command, MessageContext context, object metadata = default);
    }
}
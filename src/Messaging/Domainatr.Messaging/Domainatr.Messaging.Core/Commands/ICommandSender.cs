using System.Threading;
using System.Threading.Tasks;

namespace Domainatr.Messaging.Core.Commands
{
    public interface ICommandSender
    {
        Task<CommandExecutionResult> SendAsync<TCommand>(TCommand command, MessageContext context = default, object metadata = default, CancellationToken cancellationToken = default)
            where TCommand : class, ICommand;
    }
}
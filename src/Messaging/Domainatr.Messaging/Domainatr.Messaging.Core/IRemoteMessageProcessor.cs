using System.Threading.Tasks;
using Domainatr.Messaging.Core.Commands;

namespace Domainatr.Messaging.Core
{
    public interface IRemoteMessageProcessor
    {
        // TODO: Add option with Mode: Default (local-first then remote), Local(-Only), Remote(-Only) 
        Task<CommandExecutionResult> SendAsync<TCommand>(TCommand command, MessageContext context, object metadata)
            where TCommand : class, ICommand;
    }
}
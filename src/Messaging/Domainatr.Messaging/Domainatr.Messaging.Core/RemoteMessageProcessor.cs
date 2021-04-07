using System.Threading;
using System.Threading.Tasks;
using Domainatr.Messaging.Core.Commands;

namespace Domainatr.Messaging.Core
{
    public class RemoteMessageProcessor
        : IRemoteMessageProcessor
    {
        private readonly ICommandSender _commandSender;

        public RemoteMessageProcessor(ICommandSender commandSender)
        {
            _commandSender = commandSender;
        }

        // TODO: Replace context with options
        public async Task<CommandExecutionResult> SendAsync<TCommand>(TCommand command, MessageContext context = default, object metadata = default, CancellationToken cancellationToken = default)
            where TCommand : class, ICommand
        {
            return await _commandSender.SendAsync(command, context, metadata, cancellationToken);
        }

        public Task<CommandExecutionResult> SendAsync<TCommand>(TCommand command, MessageContext context, object metadata) where TCommand : class, ICommand
        {
            throw new System.NotImplementedException();
        }
    }
}
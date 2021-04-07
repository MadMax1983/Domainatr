using System;
using System.Threading;
using System.Threading.Tasks;
using Domainatr.Messaging.Core.DependencyInjection;

namespace Domainatr.Messaging.Core.Commands
{
    public class CommandSender
        : ICommandSender
    {
        public CommandSender(IContainer container)
        {
            Container = container;
        }
        
        protected IContainer Container { get; }
        
        public virtual async Task<CommandExecutionResult> SendAsync<TCommand>(
            TCommand command,
            MessageContext context = default,
            object metadata = default,
            CancellationToken cancellationToken = default)
            where TCommand : class, ICommand
        {
            _ = command ?? throw new ArgumentNullException(nameof(command));
            
            var commandHandler = Container.GetService<ICommandHandler<TCommand>>();
            if (commandHandler == null)
            {
                throw new Exception(); // TODO: Create CommandHandlerNotFoundException
            }

            // TODO: Implement Pre & Post checks
            // TODO: Implement options to determine what to do if pre/post checks fail
            // TODO: Implement retry policy
            await commandHandler.HandlerAsync(command, context, metadata);

            return new CommandExecutionResult(null);
        }
    }
}
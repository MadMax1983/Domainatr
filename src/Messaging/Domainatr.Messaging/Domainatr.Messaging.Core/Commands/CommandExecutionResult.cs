using System.Collections.Generic;
using System.Linq;

namespace Domainatr.Messaging.Core.Commands
{
    public class CommandExecutionResult
    {
        public CommandExecutionResult(IReadOnlyCollection<string> errors)
        {
            IsSuccessful = errors.Any();

            Errors = errors;
        }
        
        public bool IsSuccessful { get; }

        public IReadOnlyCollection<string> Errors { get; }
    }
}
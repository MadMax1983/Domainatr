using System;

namespace Domainatr.Messaging.Core.Commands
{
    public interface ICommand
    {
        Guid Id { get; }
    }
}
namespace Domainatr.Messaging.Core.DependencyInjection
{
    public interface IContainer
    {
        TService GetService<TService>();
    }
}
using System.Threading;
using System.Threading.Tasks;

namespace Domainatr.Messaging.Core.Queries
{
    public interface IQuerySender
    {
        Task<TResult> SendAsync<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default)
            where TQuery : class, IQuery<TResult>;
    }
}
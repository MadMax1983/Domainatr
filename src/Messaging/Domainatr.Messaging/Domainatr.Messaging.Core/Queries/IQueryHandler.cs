using System.Threading;
using System.Threading.Tasks;

namespace Domainatr.Messaging.Core.Queries
{
    public interface IQueryHandler<in TQuery, TResult>
        where TQuery : class, IQuery<TResult>
    {
        Task<TResult> HandlerAsync(TQuery query, CancellationToken cancellationToken = default);
    }
}
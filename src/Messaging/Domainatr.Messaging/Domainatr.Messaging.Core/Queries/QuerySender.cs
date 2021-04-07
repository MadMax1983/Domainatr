using System;
using System.Threading;
using System.Threading.Tasks;
using Domainatr.Messaging.Core.DependencyInjection;

namespace Domainatr.Messaging.Core.Queries
{
    public class QuerySender
        : IQuerySender
    {
        public QuerySender(IContainer container)
        {
            Container = container;
        }
        
        public IContainer Container { get; }

        public virtual async Task<TResult> SendAsync<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default)
            where TQuery : class, IQuery<TResult>
        {
            _ = query ?? throw new ArgumentNullException(nameof(query));
            
            var queryHandler = Container.GetService<IQueryHandler<TQuery, TResult>>();
            if (queryHandler == null)
            {
                throw new Exception(); // TODO: Create CommandHandlerNotFoundException
            }

            // TODO: Implement Pre & Post checks
            // TODO: Implement options to determine what to do if pre/post checks fail
            // TODO: Implement retry policy
            return await queryHandler.HandlerAsync(query, cancellationToken);
        }
    }
}
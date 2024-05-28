using MediatR;
using Shared.FluentResults;

namespace Abstraction.Message;

public interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, IFluentResults<TResponse>>
    where TQuery : IQuery<TResponse>
{
}

using MediatR;
using Shared.FluentResults;

namespace Abstraction.Message;

public interface IQuery<TResponse> : IRequest<IFluentResults<TResponse>>
{
}

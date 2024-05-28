using MediatR;
using Shared.FluentResults;

namespace Abstraction.Message;

public interface ICommand : IRequest<IFluentResults>
{
}

public interface ICommand<TResponse> : IRequest<IFluentResults<TResponse>>
{
}

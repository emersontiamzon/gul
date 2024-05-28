using MediatR;
using Shared.FluentResults;

namespace Abstraction.Message;

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, IFluentResults>
    where TCommand : ICommand
{
}

public interface ICommandHandler<TCommand, TResponse>
    : IRequestHandler<TCommand, IFluentResults<TResponse>>
    where TCommand : ICommand<TResponse>
{
}

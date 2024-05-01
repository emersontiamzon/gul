using MediatR;
using Shared.FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
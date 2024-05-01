using MediatR;
using Shared.FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Message;

public interface ICommand : IRequest<IFluentResults>
{
}

public interface ICommand<TResponse> : IRequest<IFluentResults<TResponse>>
{
}

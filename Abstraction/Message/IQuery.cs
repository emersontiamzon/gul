using MediatR;
using Shared.FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Message;

public interface IQuery<TResponse> : IRequest<IFluentResults<TResponse>>
{
}

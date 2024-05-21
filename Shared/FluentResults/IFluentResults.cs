using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.FluentResults;

public interface IFluentResults<T> : IFluentResults
{
    T Value { get; }

    ActionResult ToActionResult();
}

public interface IFluentResults
{
    FluentResultsStatus Status { get; }
    List<string> Messages { get; }
    Dictionary<string, object> Keys { get; }
    string ToMultiLine(string delimiter = null);
    string ToString();
}

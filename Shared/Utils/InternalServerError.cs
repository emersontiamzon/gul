using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Shared.Utils;

public class InternalServerErrorObjectResult : ObjectResult
{
    public InternalServerErrorObjectResult(object value) : base(value)
    {
        StatusCode = 500;
    }

    public InternalServerErrorObjectResult() : this(null)
    {
        StatusCode = 500;
    }
}
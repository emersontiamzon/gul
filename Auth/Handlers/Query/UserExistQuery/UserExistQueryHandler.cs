using Abstraction.Message;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Persistence.Models;
using Shared.FluentResults;

namespace Auth.Handlers.Query.UserExistQuery;

public class UserExistQueryHandler : IQueryHandler<UserExistQuery, AppUser>
{
    private readonly ILogger<UserExistQueryHandler> _logger;
    private readonly ISender _sender;
    private readonly UserManager<AppUser> _userManager;

    public UserExistQueryHandler(ILogger<UserExistQueryHandler> logger, UserManager<AppUser> userManager, ISender sender)
    {
        _logger = logger;
        _userManager = userManager;
        _sender = sender;
    }

    public async Task<IFluentResults<AppUser>> Handle(UserExistQuery request, CancellationToken cancellationToken)
    {

        var result = await _userManager.FindByEmailAsync(request.Email);

        if (result is null || result.Active == false || result.TenantId != request.TenantId)
        {
            return ResultsTo.NotFound<AppUser>().WithMessage("User does not exist");
        }

        return ResultsTo.Something(result);
    }
}
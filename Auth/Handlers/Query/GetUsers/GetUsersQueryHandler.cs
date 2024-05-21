using Abstraction.Message;
using Auth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.Models;
using Shared.FluentResults;

namespace Auth.Handlers.Query.GetUsers;

public class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, List<ServiceUserResponse>>
{
    private readonly UserManager<AppUser> _userManager;

    public GetUsersQueryHandler(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IFluentResults<List<ServiceUserResponse>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var result = await _userManager.Users.ToListAsync(cancellationToken);

        if (!result.Any())
        {
            return ResultsTo.NotFound<List<ServiceUserResponse>>().WithMessage("No Users Found");
        }

        var response = result.Where(r => r.Active).Select(m => new ServiceUserResponse
        {
            FirstName = m.FirstName,
            MiddleName = m.MiddleName,
            LastName = m.LastName,
            UserName = m.UserName ?? string.Empty,
            //TenantId = m.TenantId,
        }).ToList();

        return ResultsTo.Something(response);
    }
}

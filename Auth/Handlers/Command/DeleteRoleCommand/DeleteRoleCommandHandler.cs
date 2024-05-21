//using Abstraction.Message;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.Extensions.Logging;
//using Persistence.Models;
//using Shared.FluentResults;

//namespace Auth.Handlers.Command.DeleteRoleCommand;

//public class DeleteRoleCommandHandler : ICommandHandler<DeleteRoleCommand, bool>
//{
//    private readonly ILogger<DeleteRoleCommandHandler> _logger;
//    private readonly RoleManager<IdentityRole> _roleManager;
//    private readonly UserManager<AppUser> _userManager;

//    public DeleteRoleCommandHandler(ILogger<DeleteRoleCommandHandler> logger, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
//    {
//        _logger = logger;
//        _userManager = userManager;
//        _roleManager = roleManager;
//    }

//    public async Task<IFluentResults<bool>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
//    {
//        if (await _roleManager.FindByNameAsync(request.RoleName) is not { } role)
//        {
//            return ResultsTo.BadRequest<bool>("Role does not exist").WithMessage("Invalid argument provided.");
//        }

//        if (await _userManager.GetUsersInRoleAsync(request.RoleName) is { } usersInRole && usersInRole.Any(x => x.Active))
//        {
//            return ResultsTo.Success((await _roleManager.DeleteAsync(role)).Succeeded);
//        }

//        return ResultsTo.BadRequest<bool>("Role has active users").WithMessage("Invalid argument provided.");
//    }
//}
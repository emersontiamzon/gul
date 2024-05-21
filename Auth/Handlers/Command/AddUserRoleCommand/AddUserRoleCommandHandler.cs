//using Abstraction.Message;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.Extensions.Logging;
//using Persistence.Models;
//using Shared.FluentResults;

//namespace Auth.Handlers.Command.AddUserRoleCommand;

//public class AddUserRoleCommandHandler : ICommandHandler<AddUserRoleCommand, bool>
//{
//    private readonly ILogger<AddUserRoleCommandHandler> _logger;
//    private readonly RoleManager<IdentityRole> _roleManager;
//    private readonly UserManager<AppUser> _userManager;

//    public AddUserRoleCommandHandler(ILogger<AddUserRoleCommandHandler> logger, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
//    {
//        _logger = logger;
//        _userManager = userManager;
//        _roleManager = roleManager;
//    }

//    public async Task<IFluentResults<bool>> Handle(AddUserRoleCommand request, CancellationToken cancellationToken)
//    {
//        if (await _userManager.FindByNameAsync(request.UserName) is not { } user)
//        {
//            return ResultsTo.BadRequest<bool>("User does not exist").WithMessage("Invalid argument provided.");
//        }

//        if (await _roleManager.FindByNameAsync(request.RoleName) is not { } role)
//        {
//            return ResultsTo.BadRequest<bool>("Role does not exist").WithMessage("Invalid argument provided.");
//        }

//        return ResultsTo.Success((await _userManager.AddToRoleAsync(user, role.Name!)).Succeeded);
//    }
//}
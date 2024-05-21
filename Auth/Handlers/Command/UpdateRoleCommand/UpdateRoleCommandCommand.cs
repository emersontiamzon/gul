//using Abstraction.Message;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.Extensions.Logging;
//using Persistence.Models;
//using Shared.FluentResults;

//namespace Auth.Handlers.Command.UpdateRoleCommand;

//public class UpdateRoleCommandCommand : ICommandHandler<UpdateRoleCommand, bool>
//{
//    private readonly ILogger<UpdateRoleCommandCommand> _logger;
//    private readonly RoleManager<IdentityRole> _roleManager;
//    private readonly UserManager<AppUser> _userManager;

//    public UpdateRoleCommandCommand(ILogger<UpdateRoleCommandCommand> logger, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
//    {
//        _logger = logger;
//        _userManager = userManager;
//        _roleManager = roleManager;
//    }

//    public async Task<IFluentResults<bool>> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
//    {
//        if (await _roleManager.FindByNameAsync(request.RoleName) is not { } role)
//        {
//            return ResultsTo.BadRequest<bool>("Role does not exist").WithMessage("Invalid argument provided.");
//        }

//        role.Name = request.RoleName;
//        role.NormalizedName = request.RoleNormalizeName;

//        return ResultsTo.Something((await _roleManager.UpdateAsync(role)).Succeeded);
//    }
//}
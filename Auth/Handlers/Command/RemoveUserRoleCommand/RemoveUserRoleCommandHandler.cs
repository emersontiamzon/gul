//using Abstraction.Message;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.Extensions.Logging;
//using Persistence.Models;
//using Shared.FluentResults;

//namespace Auth.Handlers.Command.RemoveUserRoleCommand;

//public class RemoveUserRoleCommandHandler : ICommandHandler<RemoveUserRoleCommand, bool>
//{
//    private readonly ILogger<RemoveUserRoleCommandHandler> _logger;
//    private readonly UserManager<AppUser> _userManager;

//    public RemoveUserRoleCommandHandler(ILogger<RemoveUserRoleCommandHandler> logger, UserManager<AppUser> userManager)
//    {
//        _logger = logger;
//        _userManager = userManager;
//    }

//    public async Task<IFluentResults<bool>> Handle(RemoveUserRoleCommand request, CancellationToken cancellationToken)
//    {
//        var user = await _userManager.FindByNameAsync(request.UserName);

//        return user is null
//            ? ResultsTo.BadRequest<bool>("User does not exist").WithMessage("Invalid argument provided.")
//            : ResultsTo.Something((await _userManager.RemoveFromRolesAsync(user, request.RoleName)).Succeeded);
//    }
//}
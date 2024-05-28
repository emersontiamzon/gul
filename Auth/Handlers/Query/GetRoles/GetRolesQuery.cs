using Abstraction.Message;

namespace Auth.Handlers.Query.GetRoles;

public record GetRolesQuery : IQuery<List<string>>
{
}
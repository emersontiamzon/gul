using Abstraction.Message;

namespace Auth.Handlers.Query.GetUsers;

public record GetUsersQuery : IQuery<List<string>>
{
}
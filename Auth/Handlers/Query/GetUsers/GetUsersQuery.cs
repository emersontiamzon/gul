using Abstraction.Message;
using Auth.Models;

namespace Auth.Handlers.Query.GetUsers;

public record GetUsersQuery : IQuery<List<ServiceUserResponse>>
{
}
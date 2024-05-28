using Abstraction.Message;
using Persistence.Models;

namespace Auth.Handlers.Query.UserExistQuery;

public sealed record UserExistQuery(string UserName, string Email, int TenantId) : IQuery<AppUser>
{
}

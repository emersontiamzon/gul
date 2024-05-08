using Microsoft.EntityFrameworkCore;
using Persistence.Initializable;
using Persistence.Models;

namespace Auth.IdentityContext;

public interface IUsersDbContext : IInitializable
{
    DbSet<AppUser> AppUsers { get; set; }
}
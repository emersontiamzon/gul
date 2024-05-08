using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence.Models;

namespace Auth.IdentityContext;

public class UsersDbContext : IdentityDbContext<AppUser>, IUsersDbContext
{
    private readonly IConfiguration _config;

    public UsersDbContext()
    {
    }
    public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
    {
    }


    public virtual DbSet<AppUser> AppUsers { get; set; }

    public async Task Initialize()
    {
        await Database.MigrateAsync();
    }
    public async Task Init()
    {
        await Database.MigrateAsync();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var result = await base.SaveChangesAsync(cancellationToken);
        return result;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var adminId = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
        var roleId = "341743f0-asd2–42de-afbf-59kmkkmk72cf6";

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Name = "SuperAdmin",
            NormalizedName = "SUPERADMIN",
            Id = roleId,
            ConcurrencyStamp = roleId,
        });

        var appUser = new AppUser
        {
            Id = adminId,
            Email = "admin@kodelev8.com",
            EmailConfirmed = true,
            FirstName = "Super",
            LastName = "Admin",
            MiddleName = string.Empty,
            UserName = "SuperAdmin",
            NormalizedUserName = "SuperAdmin",
            ApiToken = "JH+C1Fnv72VIXbmM8aS8+UXJ6ci8Bgtn5R1MeOksvdWz11qmVKNvVQrSsbYivtzBkBikwz6s3ycyY4nyf34i/Q==",
            RefreshToken = "dMQa7YJBXc0rgNQeBeeJnabu+mpChoi4NAkO+1WnhqS+A+fRESDU2svYGdWPTH+1OkpzeHeVBPw8TbJ9p/LKXg==",
            Active = true,
        };

        //set user password
        var ph = new PasswordHasher<AppUser>();
        appUser.PasswordHash = ph.HashPassword(appUser, "SUPERADMIN");

        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<AppUser>(entity => { entity.HasData(appUser); });

        //set user role to admin
        modelBuilder.Entity<IdentityUserRole<string>>(entity =>
        {
            entity.HasKey(e => new
            {
                e.RoleId,
                e.UserId,
            });
            entity.HasData(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = adminId,
            });
        });

        // modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        // {
        //     RoleId = roleId,
        //     UserId = adminId,
        // });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to postgres with connection string from app settings during migrations
        //options.UseNpgsql(_config.GetSection("DefaultConnection").ToString());


        //var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, false);
        //var config = builder.Build();
        //var connectionString = config.GetConnectionString("DefaultConnection");

        options.UseNpgsql("User Id=postgres.inaoczhijvqasgcsltlx;Password=Umgp9PaTF5uRlwSo;Server=aws-0-ap-southeast-1.pooler.supabase.com;Port=5432;Database=postgres;");
    }
}

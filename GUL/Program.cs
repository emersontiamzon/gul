using Auth.DataContext;
using Auth.IdentityContext;
using GUL.Registrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Authentication  --- Authentications
builder.Services.AddAuthentication()
    .AddBearerToken(IdentityConstants.BearerScheme);

//Add Authoriaztion --- Authentications
builder.Services.AddAuthorization();

//Configure dbContext  --- Authentications
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<UsersDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentityCore<AppUser>().AddEntityFrameworkStores<AppDbContext>().AddApiEndpoints();

//---Authentications


//register controllers
builder.Services.AddControllersRegistration();


//scan assemblies with scrutor
builder.Services.AddScrutorRegistration();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//add Middleware --- Authentications
app.MapIdentityApi<AppUser>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

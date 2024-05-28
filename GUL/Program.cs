
using Auth.IdentityContext;
using GUL.Registrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Logging;
using Microsoft.OpenApi.Models;
using Persistence.Initializable;
using Persistence.Models;
using Registrations;
using System.IO.Compression;

var builder = WebApplication.CreateBuilder(args);

//load appsettings configuration
builder.Services.AddOptions();
builder.Services.Configure<GULConfiguration>(builder.Configuration.GetSection("PosConfiguration"));
var options = builder.Services.BuildServiceProvider().GetRequiredService<IOptions<GULConfiguration>>();

//Add Authentication  --- Authentications
builder.Services.AddAuthentication()
    .AddBearerToken(IdentityConstants.BearerScheme);

//Add Authoriaztion --- Authentications
builder.Services.AddAuthorization();

//Configure dbContext  --- Authentications
//builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<UsersDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<UsersDbContext>().AddApiEndpoints();

//---Authentications





//setup compression
builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
    options.Providers.Add<BrotliCompressionProvider>();
    options.Providers.Add<GzipCompressionProvider>();
});

builder.Services.Configure<BrotliCompressionProviderOptions>(options => { options.Level = CompressionLevel.Fastest; });
builder.Services.Configure<GzipCompressionProviderOptions>(options => { options.Level = CompressionLevel.Optimal; });



//register controllers
builder.Services.AddControllersRegistration();

//register mediatr
builder.Services.AddMediatrRegistration();

//scan assemblies with scrutor
builder.Services.AddScrutorRegistration();



builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "The API", Version = "v1" });
});

//register repositories
//builder.Services.AddRepositoriesRegistration();


// Setup OpenTelemetry Tracing w/ honeybcomb
//builder.AddOpenTelemetryAndLoggingRegistration(options.Value);

// setup fluent email
//builder.Services.AddEmailRegistrration(options.Value.Smtp);

// builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
IdentityModelEventSource.ShowPII = true;

var app = builder.Build();


// Configure the HTTP request pipeline.not able to be constructed (Error while validating the service descriptor 'ServiceType: System.IEquatable`1[Shared.Results.Error] Lifetime: Scoped ImplementationType: Shared.Results.Error': Unable to resolve service for type 'System.String' while attempting to activate 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//add Middleware --- Authentications
app.MapIdentityApi<AppUser>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Map("/exception", () => { throw new InvalidOperationException("Sample Exception"); });

//initialize and apply database migrations
var initializables = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).Where(y => typeof(IInitializable).IsAssignableFrom(y) && !y.IsInterface);
app.Run();

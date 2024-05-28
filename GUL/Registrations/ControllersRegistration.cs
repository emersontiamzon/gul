using System.Reflection;

namespace GUL.Registrations;

public static class ControllersRegistration
{
    public static void AddControllersRegistration(this IServiceCollection services)
    {
        services.AddMvc().AddApplicationPart(System.Reflection.Assembly.Load(new AssemblyName("Auth")));
    }
}
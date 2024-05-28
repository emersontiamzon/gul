namespace GUL.Registrations;

public static class ScrutorRegistration
{
    public static void AddScrutorRegistration(this IServiceCollection service)
    {
        service.Scan(
            selector => selector
                .FromAssemblies(AssemblyReference.Assembly)
                .FromAssemblies(Auth.Assembly.AssemblyReference.Assembly)
                .FromAssemblies(Persistence.Assembly.AssemblyReference.Assembly)
                .FromAssemblies(Shared.Assembly.AssemblyReference.Assembly)
                .AddClasses(false)
                .AsImplementedInterfaces()
                .WithScopedLifetime());
    }
}
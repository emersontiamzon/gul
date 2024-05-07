namespace GUL.Registrations;

public static class ScrutorRegistration
{
    public static void AddScrutorRegistration(this IServiceCollection service)
    {
        service.Scan(
            selector => selector
                .FromAssemblies(Auth.Assembly.AssemblyReference.Assembly)
                .AddClasses(false)
                .AsImplementedInterfaces()
                .WithScopedLifetime());
    }
}
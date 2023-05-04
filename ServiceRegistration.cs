

public static class ServiceRegistration
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IExpressionRepository, ExpressionRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
    }
}
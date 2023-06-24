using Microsoft.OpenApi.Models;

public static class DependencyInitializer
{
    public static IServiceCollection AddDIServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "HomeownerNotebookAPI", Version = "v1" });
        });

        return services;
    }
    public static IApplicationBuilder UseOpenApi(this IApplicationBuilder builder)
    {
        builder.UseSwagger();
        builder.UseSwaggerUI(c => {
            c.RoutePrefix = ""; c.SwaggerEndpoint("/swagger/v1/swagger.json", "HomeownerNotebook v0.1");
            });
        return builder;
    }
}
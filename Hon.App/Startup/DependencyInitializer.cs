using Microsoft.OpenApi.Models;
using Hon.Persistence;
using System.Configuration;

public static class DependencyInitializer
{
    public static IServiceCollection AddDIServices(this IServiceCollection services)
    {
        
        services.AddDbContext<HonDbContext>(options =>
            options.UseMySQL("Server=localhost;Port=3306;Database=test_db;User=root;Password=Database01!;"));
        services.AddTransient<IDatabaseService, HonDatabaseService>();

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
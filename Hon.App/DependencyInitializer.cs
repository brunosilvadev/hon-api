using Microsoft.OpenApi.Models;

public static class DependencyInitializer
{

    public static IApplicationBuilder UseOpenApi(this IApplicationBuilder builder)
    {
        builder.UseSwagger();
        builder.UseSwaggerUI(c => {
            c.RoutePrefix = ""; c.SwaggerEndpoint("/swagger/v1/swagger.json", "Croupier v0.1");
            });
        return builder;
    }
}
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseOpenApi();

app.MapGet("/", () => "Hello World!");

app.Run();

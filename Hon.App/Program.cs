using Hon.Persistence;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDIServices();

var app = builder.Build();

app.UseOpenApi();

app.MapGet("/test", () => "Hello World!");

app.MapGet("/testdb", (IDatabaseService dbService) => 
{
    dbService.GetSamples();
});


app.Run();

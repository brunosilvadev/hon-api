using Hon.Persistence;
using Hon.Model;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDIServices();
builder.Services.AddCors();

var app = builder.Build();

app.UseOpenApi();
app.UseCors(options =>
    options.WithOrigins("http://localhost:4200")
    .AllowAnyMethod()
    .AllowAnyHeader()
);

app.MapGet("/list", async (IDatabaseService dbService) => 
{
    return Results.Ok(await dbService.GetSamples());

});

app.MapGet("/get{id}", async (int id, IDatabaseService dbService) =>
{
    return Results.Ok(await dbService.GetSample(id));
});

app.MapPost("/create", async (SampleModel sample, IDatabaseService dbService) =>
{
    await dbService.AddSample(sample);
    return Results.Ok();
});

app.MapPut("/update", async (SampleModel sample, IDatabaseService dbService) =>
{
    await dbService.UpdateSample(sample);
    return Results.Ok(sample);
});

app.MapDelete("/delete{id}", async (int id, IDatabaseService dbService) =>
{
    await dbService.DeleteSample(id);
    return Results.Ok();
});

app.MapGet("/cards", async (IDatabaseService dbService) =>
{
    return Results.Ok(await dbService.ListCards());
});

app.MapPost("/add-card", async(Card card, IDatabaseService dbService) =>
{
    await dbService.AddCard(card);
    return Results.Ok();
});

app.Run();

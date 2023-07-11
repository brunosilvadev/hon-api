using Hon.Persistence;
using Hon.Model;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDIServices();

var app = builder.Build();

app.UseOpenApi();

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
    return Results.CreatedAtRoute($"/create/{sample.SampleId}",sample);
});

app.MapPut("/update", async (SampleModel sample, IDatabaseService dbService) =>
{
    await dbService.UpdateSample(sample);
    return Results.Ok(sample);
});

app.MapDelete("/delte{id}", async (int id, IDatabaseService dbService) =>
{
    await dbService.DeleteSample(id);
    return Results.Ok();
});

app.Run();

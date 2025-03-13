using Microsoft.EntityFrameworkCore;
using Adam_s_Notebook_ASP.NET_API;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Model3dDb>(opt => opt.UseInMemoryDatabase("Model3dList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/Model3ditems", async (Model3dDb db) =>
    await db.Model3ds.ToListAsync());

app.MapGet("/Model3ditems/complete", async (Model3dDb db) =>
    await db.Model3ds.Where(t => t.IsComplete).ToListAsync());

app.MapGet("/Model3ditems/{id}", async (int id, Model3dDb db) =>
    await db.Model3ds.FindAsync(id)
        is Model3d Model3d
            ? Results.Ok(Model3d)
            : Results.NotFound());

app.MapPost("/Model3ditems", async (Model3d Model3d, Model3dDb db) => {
    db.Model3ds.Add(Model3d);
    await db.SaveChangesAsync();

    return Results.Created($"/Model3ditems/{Model3d.Id}", Model3d);
});

app.MapPut("/Model3ditems/{id}", async (int id, Model3d inputModel3d, Model3dDb db) => {
    var Model3d = await db.Model3ds.FindAsync(id);

    if (Model3d is null) return Results.NotFound();

    Model3d.Name = inputModel3d.Name;
    Model3d.IsComplete = inputModel3d.IsComplete;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/Model3ditems/{id}", async (int id, Model3dDb db) => {
    if (await db.Model3ds.FindAsync(id) is Model3d Model3d) {
        db.Model3ds.Remove(Model3d);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});

app.Run();
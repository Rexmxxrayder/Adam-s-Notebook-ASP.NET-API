using Adam_s_Notebook_ASP.NET_API.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddDbContext<ModelContext>(options => {
    options.UseSqlServer("Server=ANOMALOCARIS;Database=Models;Trusted_Connection=True;TrustServerCertificate=True;");
});


var app = builder.Build();

app.UseCors("AllowAllOrigins");

app.MapGet("/api/model", async () =>
{
    var filePath = "C://Sharkore//Web//AdamNotebook//Adam-s-Notebook-ASP.NET-API//Adam-s-Notebook-ASP.NET-API//Data//Models3D//LetterBoss//LetterBoss.glb";

    if (File.Exists(filePath))
    {
        var fileBytes = await File.ReadAllBytesAsync(filePath);
        return Results.File(fileBytes, "application/x-fbx", "LetterBoss.fbx");
    }
    else
    {
        return Results.NotFound("File not found");
    }
});

app.Run();

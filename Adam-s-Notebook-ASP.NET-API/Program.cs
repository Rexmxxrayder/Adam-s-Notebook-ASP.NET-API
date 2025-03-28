using Adam_s_Notebook_ASP.NET_API.Data;
using Adam_s_Notebook_ASP.NET_API.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING_ADAMSNOTEBOOKAPI");

if (!string.IsNullOrEmpty(connectionString))
{
    builder.Configuration["ConnectionStrings:CommanderConnection"] = connectionString;
}

builder.Services.Configure<FilePaths>(builder.Configuration.GetSection("FilePaths"));

builder.Services.AddDbContext<AssetContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CommanderConnection"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


builder.Services.AddControllers().AddNewtonsoftJson(s => {
    s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IAssetRepo<Mesh>, SqlMeshRepo>();
builder.Services.AddScoped<IAssetRepo<Image>, SqlImageRepo>();

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


app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();

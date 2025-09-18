using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using CaLabApi.Data;
using CaLabApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbContext<CaLabDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));

// Register services
builder.Services.AddScoped<IAnalysisService, AnalysisService>();
builder.Services.AddScoped<IParameterService, ParameterService>();
builder.Services.AddScoped<ISampleTypeService, SampleTypeService>();
builder.Services.AddScoped<IMethodService, MethodService>();

// Add controllers
builder.Services.AddControllers();

// Add API Explorer (required for Swagger)
builder.Services.AddEndpointsApiExplorer();

// Add Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "CA Lab API", 
        Version = "v1",
        Description = "API untuk sistem laboratorium CA"
    });
});

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowNextJS", policy =>
    {
        policy.WithOrigins("http://localhost:3000", "https://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();

// Configure pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CA Lab API V1");
        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowNextJS");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
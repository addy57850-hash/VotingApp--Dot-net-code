var builder = WebApplication.CreateBuilder(args);

// ?? Add CORS service
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// ?? Add other services
builder.Services.AddControllers();

var app = builder.Build();

// ?? Use CORS (IMPORTANT: before Authorization)
app.UseCors("AllowAngular");

app.UseAuthorization();

app.MapControllers();

app.Run();

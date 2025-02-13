
var builder = WebApplication.CreateBuilder(args);

// Configuração de CORS
var corsPolicy = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicy,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // Permite Angular consumir a API 
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Adiciona os serviços necessários para Swagger
builder.Services.AddControllers(); // Adiciona o controller
builder.Services.AddEndpointsApiExplorer(); // Adiciona o endpoint no Swagger

// Add Mediator DI
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));


var app = builder.Build();

var port = Environment.GetEnvironmentVariable("PORT") ?? "8081";
app.Urls.Add($"http://*:{port}");

app.UseSwagger(); // Habilita o Swagger
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
    c.RoutePrefix = "swagger";
});

app.UseCors(corsPolicy);

app.MapControllers();

app.Run();
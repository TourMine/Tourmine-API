using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Tourmine.Application.UseCase;
using Tourmine.Application.UseCase.Auth;
using Tourmine.Application.UseCase.Interfaces;
using Tourmine.Infrastructure;
using Tourmine.Infrastructure.Authentication;
using Tourmine.Infrastructure.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var key = Encoding.UTF8.GetBytes(Settings.SecretKey);

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddControllers(); // Adiciona o controller
builder.Services.AddEndpointsApiExplorer(); // Adiciona o endpoint no Swagger
builder.Services.AddSwaggerGen();  // Adiciona o Swagger

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

// UseCase
builder.Services.AddScoped<IRegisterUseCase, RegisterUseCase>();
builder.Services.AddScoped<ILoginUseCase, LoginUseCase>();

// Services
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();

// Add Mediator DI
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

var app = builder.Build();

var port = Environment.GetEnvironmentVariable("PORT") ?? "8081";
app.Urls.Add($"http://*:{port}");
app.Urls.Add("https://localhost:7143");  // Adiciona a URL para HTTPS

app.UseSwagger(); // Habilita o Swagger
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
    c.RoutePrefix = "swagger"; // Isso define o caminho para o Swagger UI
    c.ConfigObject.AdditionalItems["https"] = false;
});

app.UseCors(corsPolicy);

app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Refit;
using System.Text;
using Tourmine.Application.ExternalServices.Subscription;
using Tourmine.Application.ExternalServices.Tournament;
using Tourmine.Application.UseCase.Auth;
using Tourmine.Application.UseCase.Interfaces.Auth;
using Tourmine.Application.UseCase.Interfaces.Users;
using Tourmine.Application.UseCase.User;
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
builder.Services.AddScoped<IUpdateUserUseCase, UpdateUserUseCase>();

// Services
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();

// Refit Services
builder.Services.AddRefitClient<ITournamentService>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7051"));

builder.Services.AddRefitClient<ISubscriptionService>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7051"));

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
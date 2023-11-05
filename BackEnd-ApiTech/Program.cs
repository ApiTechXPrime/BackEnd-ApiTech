using BackEnd_ApiTech.TechXPrime.Domain.Repositories;
using BackEnd_ApiTech.TechXPrime.Domain.Services;
using BackEnd_ApiTech.TechXPrime.Mapping;
using BackEnd_ApiTech.TechXPrime.Services;
using BackEnd_ApiTech.Shared.Persistence.Contexts;
using BackEnd_ApiTech.Shared.Persistence.Repositories;
using BackEnd_ApiTech.TechXPrime.Persistence.Repositories;
using BackEnd_ApiTech.security.Domain.Repositories;
using BackEnd_ApiTech.security.Domain.Services.Communication;
using BackEnd_ApiTech.security.Persistence.Repository;
using BackEnd_ApiTech.security.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at 
https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Database Connection
var connectionString = 
    builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());

// Add lowercase routes
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Dependency Injection Configuration
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAnalyticRepository, AnalyticsRepository>();
builder.Services.AddScoped<IAnalyticService, AnalyticService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// AutoMapper Configuration
builder.Services.AddAutoMapper(
    typeof(ModelToResourceProfile), 
    typeof(ResourceToModelProfile),
    typeof(BackEnd_ApiTech.security.Mapping.ModelToResourceProfile),
    typeof(BackEnd_ApiTech.security.Mapping.ResourceToModelProfile));

var app = builder.Build();

// Validation for ensuring Database Objects are created
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
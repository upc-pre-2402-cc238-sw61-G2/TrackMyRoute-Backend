using backend.payments.Application.Internal.CommandServices;
using backend.payments.Application.Internal.QueryServices;
using backend.payments.Domain.Repositories;
using backend.payments.Domain.Services;
using backend.payments.Infrastructure.Persistence.EFC.Repositories;


using ACME.LearningCenter_Platform.Profiles;
using backend.IAM;
using backend.IAM.Application.Internal.CommandServices;
using backend.IAM.Application.Internal.OutboundServices;
using backend.IAM.Application.Internal.QueryServices;
using backend.IAM.Infrastructure.Hashing.BCrypt.Services;
using backend.IAM.Infrastructure.Persistence.EFC.Repositories;
using backend.IAM.Infrastructure.Tokens.JWT.Configuration;
using backend.IAM.Infrastructure.Tokens.JWT.Services;
using backend.IAM.Interfaces.ACL;
using backend.IAM.Interfaces.ACL.Services;
using backend.Profiles;
using backend.Shared.Domain.Repositories;
using backend.Shared.Infrastructure.Persistence.EFC.Configuration;
using backend.Shared.Infrastructure.Persistence.EFC.Repositories;
using backend.tracking;
using backend.Promos.Application.Internal.CommandServices;
using backend.Promos.Application.Internal.QueryServices;
using backend.Promos.Domain.Repositories;
using backend.Promos.Domain.Services;
using backend.Promos.Infrastructure.Persistence.EFC.Repositories;
using backend.Shared.Infrastructure.Interfaces.ASP.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(options =>
    {
    options.Conventions.Add(new KebabCaseRouteNamingConvention());
});


// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Levels

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "TrackMyRoute_WebService",
                Version = "v1",
                Description = "TRACK MY ROUTE PLATFORM",
                Contact = new OpenApiContact
                {
                    Name = "TRACK MY ROUTE",
                    Email = "contact@TRACKMR.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.EnableAnnotations();
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                },
                Array.Empty<string>()
            }
        }); 

    });

// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Configure Dependency Injection

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Payments Bounded Context Injection Configuration
builder.Services.AddScoped<IPaymentsRepository, PaymentsRepository>();
builder.Services.AddScoped<IPaymentsCommandService, PaymentsCommandService>();
builder.Services.AddScoped<IPaymentsQueryService, PaymentsQueryService>();

// Tracking Bounded Context Injection Configuration
builder.Services.AddScoped<IBusRouteRepository, BusRouteRepository>();
builder.Services.AddScoped<IBusRouteCommandService, BusRouteCommandService>();
builder.Services.AddScoped<IBusRouteQueryService, BusRouteQueryService>();

builder.Services.AddScoped<IPromoRepository, PromoRepository>();
builder.Services.AddScoped<IPromoCommandService, PromoCommandService>();
builder.Services.AddScoped<IPromoQueryService, PromoQueryService>();

// Promos Bounded Context Injection Configuration
builder.Services.AddScoped<IPromoRepository, PromoRepository>();
builder.Services.AddScoped<IPromoCommandService, PromoCommandService>();
builder.Services.AddScoped<IPromoQueryService, PromoQueryService>();

// Profiles Bounded Context Injection Configuration
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileCommandService, ProfileCommandService>();
builder.Services.AddScoped<IProfileQueryService, ProfileQueryService>();
builder.Services.AddScoped<IProfilesContextFacade, ProfilesContextFacade>();

// IAM Bounded Context Injection Configuration
// TokenSettings Configuration
builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryServices, UserQueryServices>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHashingService, HashingService>();
builder.Services.AddScoped<IIamContextFacade, IamContextFacade>();



var app = builder.Build();


// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}


app.UseSwagger();

app.UseSwaggerUI();

app.UseCors("AllowAllPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


using Autofac;
using Autofac.Extensions.DependencyInjection;
using Serilog;
using MyKnowledgeManager.WebApi.Controllers;
using Microsoft.IdentityModel.Tokens;
using MyKnowledgeManager.SharedKernel.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext(connectionString: connectionString);

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://localhost:7230";

        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateAudience = false
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(ConfigConstants.RequireAdministratorRole, policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "webApi");
    });

    options.AddPolicy(ConfigConstants.RequireAdministratorRole, policy =>
    {
        policy.RequireRole(CustomRoles.Administrator);
    });

    options.AddPolicy(ConfigConstants.RequireSystemAgentRole, policy =>
    {
        policy.RequireRole(CustomRoles.SystemAgent, CustomRoles.Administrator);
    });

    options.AddPolicy(ConfigConstants.RequireSupervisorRole, policy =>
    {
        policy.RequireRole(CustomRoles.Supervisor, CustomRoles.Administrator);
    });
});

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new DefaultCoreModule());
    containerBuilder.RegisterModule(new DefaultInfrastructureModule(builder.Environment.EnvironmentName == "Development"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCookiePolicy();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

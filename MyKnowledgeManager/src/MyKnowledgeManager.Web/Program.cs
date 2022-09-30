using Autofac;
using Autofac.Extensions.DependencyInjection;
using MyKnowledgeManager.Core;
using MyKnowledgeManager.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext(connectionString: connectionString);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new DefaultCoreModule());
    containerBuilder.RegisterModule(new DefaultInfrastructureModule(builder.Environment.EnvironmentName == "Development"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCookiePolicy();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

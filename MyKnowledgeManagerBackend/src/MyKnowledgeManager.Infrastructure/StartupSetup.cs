using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyKnowledgeManager.Infrastructure.Data;

namespace MyKnowledgeManager.Infrastructure
{
    public static class StartupSetup
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
    }
}

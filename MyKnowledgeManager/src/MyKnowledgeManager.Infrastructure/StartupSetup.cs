using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyKnowledgeManager.Infrastructure.Data;

namespace MyKnowledgeManager.Infrastructure
{
    public static class StartupSetup
    {
        public static void AddDbContextPool(this IServiceCollection services, string connectionString)
        {
            services.AddDbContextPool<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
    }
}

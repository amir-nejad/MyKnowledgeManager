using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyKnowledgeManager.IdentityServer.Utilities;

namespace MyKnowledgeManager.IdentityServer.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole[]
            {
                new IdentityRole()
                {
                    Id = "9c9fb092-df93-4b41-8d81-3de2341d6586",
                    Name = CustomRoles.Administrator,
                    NormalizedName = CustomRoles.Administrator.ToUpper()
                },
                new IdentityRole()
                {
                    Id = "22ecab7f-3c25-49a4-8653-eea401358c34",
                    Name = CustomRoles.Supervisor,
                    NormalizedName = CustomRoles.Supervisor.ToUpper()
                },
                new IdentityRole()
                {
                    Id = "9c07fc5e-31d7-41d6-80bd-3845f3d0f6a7",
                    Name = CustomRoles.EndUser,
                    NormalizedName = CustomRoles.EndUser.ToUpper(),
                },
                new IdentityRole()
                {
                    Id = "38ebf21d-fa33-4d4d-a243-1f1536d14e8c",
                    Name = CustomRoles.SystemAgent,
                    NormalizedName = CustomRoles.SystemAgent.ToUpper(),
                },
            });
        }
    }
}
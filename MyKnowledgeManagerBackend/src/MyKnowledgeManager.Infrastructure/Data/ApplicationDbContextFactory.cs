using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace MyKnowledgeManager.Infrastructure.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        private readonly IMediator? _mediator;

        public ApplicationDbContextFactory()
        {

        }

        public ApplicationDbContextFactory(IMediator mediator)
        {
            _mediator = mediator;
        }

        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EcommerceDb;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new ApplicationDbContext(optionsBuilder.Options, _mediator);
        }
    }
}

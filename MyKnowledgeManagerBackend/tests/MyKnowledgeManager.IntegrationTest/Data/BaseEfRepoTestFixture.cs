using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using MyKnowledgeManager.Core.Entities;
using MyKnowledgeManager.Infrastructure.Data;
using MyKnowledgeManager.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyKnowledgeManager.IntegrationTest.Data
{
    public abstract class BaseEfRepoTestFixture
    {
        protected ApplicationDbContext _context;

        protected BaseEfRepoTestFixture()
        {
            var options = CreateNewContextOptions();
            var mockMediator = new Mock<IMediator>();

            this._context = new ApplicationDbContext(options, mockMediator.Object);
        }

        protected static DbContextOptions<ApplicationDbContext> CreateNewContextOptions()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            builder
                .UseInMemoryDatabase("MyKnowledgeManagerTest")
                .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        protected EfRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new EfRepository<T>(_context);
        }
    }
}

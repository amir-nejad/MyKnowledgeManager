using Autofac;
using MediatR;
using MediatR.Pipeline;
using MyKnowledgeManager.Core.Entities;
using MyKnowledgeManager.Core.Interfaces;
using MyKnowledgeManager.Infrastructure.Data;
using MyKnowledgeManager.SharedKernel.Interfaces;
using System.Reflection;
using MediatR.Extensions.Autofac.DependencyInjection;
using Module = Autofac.Module;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;

namespace MyKnowledgeManager.Infrastructure
{
    public class DefaultInfrastructureModule : Module
    {
        private readonly bool _isDevelopment;
        private readonly Assembly[] _assemblies;

        public DefaultInfrastructureModule(bool isDevelopment, Assembly? callingAssembly = null)
        {
            _isDevelopment = isDevelopment;

            var assemblies = new List<Assembly>
        {
            typeof(Knowledge).Assembly,        // Core assembly
            typeof(StartupSetup).Assembly      // Infrastructure assembly
        };

            if (callingAssembly != null)
            {
                assemblies.Add(callingAssembly);
            }

            _assemblies = assemblies.ToArray();
        }

        protected override void Load(ContainerBuilder builder)
        {
            if (_isDevelopment)
            {
                RegisterDevelopmentOnlyDependencies(builder);
            }
            else
            {
                RegisterProductionOnlyDependencies(builder);
            }

            RegisterCommonDependencies(builder);
        }

        private void RegisterCommonDependencies(ContainerBuilder builder)
        {
            // Register generic repository implementations
            builder.RegisterGeneric(typeof(EfRepository<>))
                .As(typeof(IRepository<>))
                .As(typeof(IReadRepository<>))
                .InstancePerLifetimeScope();

            // Configure MediatR
            var mediatrConfig = MediatRConfigurationBuilder
                .Create(_assemblies)
                .WithAllOpenGenericHandlerTypesRegistered()
                .Build();

            // Register MediatR with Autofac
            builder.RegisterMediatR(mediatrConfig);

            // Register additional services
            builder.RegisterType<EmailSender>()
                .As<IEmailSender>()
                .InstancePerLifetimeScope();
        }

        private void RegisterProductionOnlyDependencies(ContainerBuilder builder)
        {
        }

        private void RegisterDevelopmentOnlyDependencies(ContainerBuilder builder)
        {
        }
    }
}
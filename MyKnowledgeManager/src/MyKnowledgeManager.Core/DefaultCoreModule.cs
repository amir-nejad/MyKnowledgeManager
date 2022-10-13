using Autofac;
using MyKnowledgeManager.Core.Interfaces;
using MyKnowledgeManager.Core.Services;

namespace MyKnowledgeManager.Core
{
    public class DefaultCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<KnowledgeService>()
                .As<IKnowledgeService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<KnowledgeTagService>()
                .As<IKnowledgeTagService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<KnowledgeTagRelationService>()
                .As<IKnowledgeTagRelationService>()
                .InstancePerLifetimeScope();
        }
    }
}

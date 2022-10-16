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
                .InstancePerDependency();

            builder.RegisterType<KnowledgeTagService>()
                .As<IKnowledgeTagService>()
                .InstancePerDependency();

            builder.RegisterType<KnowledgeTagRelationService>()
                .As<IKnowledgeTagRelationService>()
                .InstancePerDependency();
        }
    }
}

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

            builder.RegisterType<TrashManager<Knowledge>>()
                .As<ITrashManager<Knowledge>>()
                .InstancePerDependency();

            builder.RegisterType<TrashManager<KnowledgeTag>>()
                .As<ITrashManager<KnowledgeTag>>()
                .InstancePerDependency();

            builder.RegisterType<TrashManager<KnowledgeTagRelation>>()
                .As<ITrashManager<KnowledgeTagRelation>>()
                .InstancePerDependency();
        }
    }
}

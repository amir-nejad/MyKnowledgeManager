using System.Reflection;

namespace MyKnowledgeManager.Infrastructure
{
    public class DefaultInfrastructureModule : Module
    {
        private readonly bool _isDevelopment = false;
        private readonly List<Assembly> _assemblies = new List<Assembly>();


        public DefaultInfrastructureModule(bool isDevelopment, Assembly? callingAssembly = null)
        {
            _isDevelopment = isDevelopment;
        }
    }
}
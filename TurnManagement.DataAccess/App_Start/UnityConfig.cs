using TurnManagement.DataAccess.Interfaces.Persistence.Core;
using TurnManagement.DataAccess.Persistence.Core;
using Unity;
using Unity.Lifetime;
using Unity.RegistrationByConvention;

namespace TurnManagement.DataAccess.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents(IUnityContainer container)
        {
            container.RegisterTypes(
                AllClasses.FromAssemblies(typeof(UnityConfig).Assembly),
                WithMappings.FromMatchingInterface,
                WithName.Default);

            //Singleton DataContext Implementation
            container.RegisterType<ITurnManagementDataContext, TurnManagementDataContext>(new HierarchicalLifetimeManager());
        }
    }
}

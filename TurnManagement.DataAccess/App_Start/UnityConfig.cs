using Unity;
using Unity.RegistrationByConvention;

namespace TurnManagement.DataAccess.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents(IUnityContainer container)
        {
            CrossCutting.App_Start.UnityConfig.RegisterComponents(container);

            container.RegisterTypes(
                AllClasses.FromAssemblies(typeof(UnityConfig).Assembly),
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.ContainerControlled);
        }
    }
}

using Unity;
using Unity.RegistrationByConvention;

namespace TurnManagement.Business.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents(IUnityContainer container)
        {
            //Register Component from Dependet Layers
            DataAccess.App_Start.UnityConfig.RegisterComponents(container);

            container.RegisterTypes(
                AllClasses.FromAssemblies(typeof(UnityConfig).Assembly),
                WithMappings.FromMatchingInterface,
                WithName.Default);
        }
    }
}

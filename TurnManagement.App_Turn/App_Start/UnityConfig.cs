using System;
using Unity;
using Unity.RegistrationByConvention;

namespace TurnManagement.App_Turn.App_Start
{
    public static class UnityConfig
    {
        #region Unity Container

        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterComponents(container);
            return container;
        });
        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        
        #endregion

        public static void RegisterComponents(IUnityContainer container)
        {
            //Register Component from Dependet Layers
            Business.App_Start.UnityConfig.RegisterComponents(container);

            container.RegisterTypes(
                AllClasses.FromAssemblies(typeof(UnityConfig).Assembly),
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.ContainerControlled);
        }
    }
}

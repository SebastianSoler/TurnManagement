namespace TurnManagement.ViewModels.App_Start
{
    public static class UnityActivator
    {
        /// <summary>Disposes the Unity container when the application is shut down.</summary>
        public static void Shutdown()
        {
            var container = UnityConfig.GetConfiguredContainer();
            container.Dispose();
        }
    }
}

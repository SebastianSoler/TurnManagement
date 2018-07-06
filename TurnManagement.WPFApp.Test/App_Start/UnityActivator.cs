namespace TurnManagement.WPFApp.Test.App_Start
{
    public static class UnityActivator
    {
        public static void Start()
        {
            var container = UnityConfig.GetConfiguredContainer();
        }
        /// <summary>Disposes the Unity container when the application is shut down.</summary>
        public static void Shutdown()
        {
            var container = UnityConfig.GetConfiguredContainer();
            container.Dispose();
        }
    }
}

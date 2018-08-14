using Dna;
using Microsoft.Extensions.DependencyInjection;
using TurnManagement.App_Turn.ViewModel.Application;

namespace TurnManagement.App_Turn.DI.Utils
{
    public static class FrameworkConstructionVM
    {
        /// <summary>
        /// Injects the view models needed for application
        /// </summary>
        /// <param name="construction"></param>
        /// <returns></returns>
        public static FrameworkConstruction AddViewModels(this FrameworkConstruction construction)
        {
            // Bind to a single instance of Application view model
            construction.Services.AddSingleton<ApplicationViewModel>();

            // Return the construction for chaining
            return construction;
        }

        /// <summary>
        /// Injects the Fasetto Word client application services needed
        /// for the Fasetto Word application
        /// </summary>
        /// <param name="construction"></param>
        /// <returns></returns>
        public static FrameworkConstruction AddClientServices(this FrameworkConstruction construction)
        {
            // Bind a UI Manager
            construction.Services.AddTransient<IUIManager, UIManager>();

            // Return the construction for chaining
            return construction;
        }
    }
}

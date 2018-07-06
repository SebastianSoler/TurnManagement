using CommonServiceLocator;
using TurnManagement.Business.Interfaces.Services;
using TurnManagement.Business.Services;
using TurnManagement.DataAccess.Interfaces.Persistence.Repositories;
using TurnManagement.DataAccess.Persistence.Repositories;
using Unity;
using Unity.Lifetime;
using Unity.ServiceLocation;

namespace TurnManagement.WPFApp.Test.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            //cambiar SimpleIoC por Unity
            var unityContainer = new UnityContainer();
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(unityContainer));

            unityContainer.RegisterType<IApplicationUserService, ApplicationUserService>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IApplicationUserRepository, ApplicationUserRepository>(new ContainerControlledLifetimeManager());

            unityContainer.RegisterType<TestViewModel>();


            //unityContainer.Resolve<>().RegisterAssociation<TestViewModel, Test>();
        }

        #region ViewModels

        //public MainViewModel Main
        //{
        //    get
        //    {
        //        return ServiceLocator.Current.GetInstance<MainViewModel>();
        //    }
        //}

        public TestViewModel TestViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TestViewModel>();
            }
        }

        #endregion

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
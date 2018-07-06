/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:TurnManagement.ViewModels"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using System;
using System.Data.Entity;
using CommonServiceLocator;
using TurnManagement.Business.Core;
using TurnManagement.Business.Interfaces.Core;
using TurnManagement.Business.Interfaces.Services;
using TurnManagement.Business.Services;
using TurnManagement.DataAccess.Interfaces.Persistence.Core;
using TurnManagement.DataAccess.Interfaces.Persistence.Repositories;
using TurnManagement.DataAccess.Migrations.Initializers;
using TurnManagement.DataAccess.Persistence.Core;
using TurnManagement.DataAccess.Persistence.EntityConfiguration;
using TurnManagement.DataAccess.Persistence.Repositories;
using TurnManagement.Domain.Entities;
using TurnManagement.ViewModels.Interfaces;
using TurnManagement.ViewModels.ViewModel;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.ServiceLocation;

namespace TurnManagement.ViewModels
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
            var unityContainer = new UnityContainer();
            //.RegisterType<>();

            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(unityContainer));

            unityContainer.RegisterType<ITurnManagementDataContext, TurnManagementDataContext>();

            //unityContainer.RegisterType(typeof(IBaseCrudRepository<>), typeof(BaseCrudRepository<>), new TransientLifetimeManager());

            //unityContainer.RegisterType<BaseEntity>();

            //unityContainer.RegisterType(typeof(IBaseService<>), typeof(BaseService<>), new TransientLifetimeManager());
            

            unityContainer.RegisterType<IApplicationUserRepository, ApplicationUserRepository>();
            

            unityContainer.RegisterType<IApplicationUserService, ApplicationUserService>();

            //unityContainer.RegisterType<ApplicationUserService>(new InjectionConstructor(
            //    new ResolvedParameter<ITurnManagementDataContext>()));

            //unityContainer.RegisterType<IBaseCommandViewModel>();
            //unityContainer.RegisterType<TestViewModel>(new ContainerControlledLifetimeManager());

            unityContainer.RegisterType<IBaseCommandViewModel, TestViewModel>();
            //unityContainer.RegisterType<MainViewModel>();
        }

        #region ViewModels

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

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
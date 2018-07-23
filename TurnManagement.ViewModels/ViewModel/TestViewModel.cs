using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using TurnManagement.Business.Interfaces.Services;
using TurnManagement.Domain.Entities;
using TurnManagement.ViewModels.EntitiesVM;
using TurnManagement.ViewModels.Interfaces;

namespace TurnManagement.ViewModels.ViewModel
{
    public class TestViewModel : ViewModelBase , IBaseCommandViewModel
    {
        private readonly IApplicationUserService applicationUserService;
        
        #region Model Property : ApplicationUserVM
        /// <summary>
        /// The <see cref="ApplicationUserVM" /> property's name.
        /// </summary>
        public const string ApplicationUserVMPropertyName = "ApplicationUserVM";

        private ApplicationUserVM applicationUserVM = new ApplicationUserVM();

        /// <summary>
        /// Sets and gets the ApplicationUserVM property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ApplicationUserVM ApplicationUserVM
        {
            get
            {
                return applicationUserVM;
            }
            set
            {
                Set(() => ApplicationUserVM, ref applicationUserVM, value);
            }
        }


        #endregion

        public RelayCommand _addApplicationUser { get; set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary> 
        public TestViewModel(IApplicationUserService applicationUserService)
        {
            this.applicationUserService = applicationUserService;

            _addApplicationUser = new RelayCommand(AddCommand);

        }

        #region Commands Implementations

        public void AddCommand()
        {
            var userName = ApplicationUserVM.UserName;
            var userPass = ApplicationUserVM.Password;

            //Validaciones

            ApplicationUser newUser = new ApplicationUser()
            {
                UserName = userName,
                Password = userPass
            };

            var newId = applicationUserService.Add(newUser);
        }

        public void GetCommand()
        {
            throw new System.NotImplementedException();
        }

        public void GetAllCommand()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}

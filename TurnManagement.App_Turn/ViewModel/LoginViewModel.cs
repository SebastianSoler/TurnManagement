using System;
using System.Security;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using Propago.Net.CrossCutting.DDBBUtils;
using TurnManagement.App_Turn.DialogControls.Checks;
using TurnManagement.App_Turn.ViewModel.Application;
using TurnManagement.App_Turn.ViewModel.Base;
using TurnManagement.Business.Interfaces.Services;
using TurnManagement.CrossCutting.Strings;
using TurnManagement.Domain.Entities;

namespace TurnManagement.App_Turn.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IApplicationUserService applicationUserService;

        private ApplicationViewModel applicationViewModel;

        //Properties
        public bool IsLog { get; set; } = false;

        public string StatusMessage { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string PasswordPlainText { get; set; } = string.Empty;

        //Commands
        public RelayCommand LogUserCommand { get; set; }

        public RelayCommand ForgetPassword { get; set; }

        public RelayCommand SendEmail { get; set; }

        /// <summary>
        /// Initializes a new instance of the LoginViewModel class.
        /// </summary> 
        public LoginViewModel(IApplicationUserService applicationUserService)
        {
            this.applicationUserService = applicationUserService;

            applicationViewModel = new ApplicationViewModel();

            LogUserCommand = new RelayCommand(execute: () => LoguinUserCommand());

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            ForgetPassword = new RelayCommand(execute: () => ForgetThePaswordInfo());
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

            SendEmail = new RelayCommand(SendEmailForPasswordBlank);
        }

        #region  Commands Implements

        public void LoguinUserCommand()
        {
            try
            {
                if (DDBBAccess.ValidateDBConnection())
                {
                    var I = 0;
                }

                if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(PasswordPlainText))
                {
                    StatusMessage = string.Concat(AccountMessages.WrongCredentials, "\n\nVerifique que los campos no esten incompletos.");
                    PasswordPlainText = string.Empty;
                    UserName = string.Empty;
                }
                else
                {
                    ApplicationUser logUser = new ApplicationUser()
                    {
                        UserName = UserName,
                        Password = PasswordPlainText
                    };

                    IsLog = applicationUserService.LoginUser(logUser);

                    StatusMessage = IsLog ? AccountMessages.CorrectCredentials : AccountMessages.WrongCredentials;
                }

                var resp = PostLogAction(IsLog);
            }
            catch (Exception)
            {
                //throw ex; ver si hace fata mostrar mensaje de Error con Message box Sencillo.
            }
        }

        private async Task PostLogAction(bool isLog)
        {
            if (isLog)
            {
                try
                {
                    //Loggin Successfuly Open Main Page
                    applicationViewModel.GoToPage(CrossCutting.Enumerations.ApplicationPage.Main);
                }
                catch (Exception){}
            }
            else
            {
                try
                {
                    var result = await CheckDisplayError.DisplayErrorMessageBox(GeneralMessages.LoginTitle, StatusMessage);

                    // Display error
                    if (result)
                    {
                        return;
                    }
                }
                catch (Exception){}
            }
        }

        private async Task ForgetThePaswordInfo()
        {
            try
            {
                var result = await CheckDisplayError.DisplayErrorMessageBox(GeneralMessages.InfoContact, AccountMessages.ForgetPassContactInfo);

                // Display error
                if (result)
                {
                    return;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SendEmailForPasswordBlank()
        {
            //Enviar mail y confirmar envio con Message Box sencillo.
        }

        #endregion
    }
}

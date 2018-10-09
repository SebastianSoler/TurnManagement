using System;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using Propago.Net.CrossCutting.DDBBUtils;
using TurnManagement.App_Turn.ViewModel.Application;
using TurnManagement.App_Turn.ViewModel.Base;
using TurnManagement.App_Turn.ViewModel.Dialogs;
using TurnManagement.Business.Interfaces.Services;
using TurnManagement.CrossCutting.Enumerations;
using TurnManagement.CrossCutting.Strings;
using TurnManagement.Domain.Entities;

namespace TurnManagement.App_Turn.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IApplicationUserService applicationUserService;

        private ApplicationViewModel applicationViewModel;

        private MessageDialogBoxViewModel messageDialogBoxViewModel;

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

            //applicationViewModel = new ApplicationViewModel();
            applicationViewModel = DI.DI.ViewModelApplication;

            LogUserCommand = new RelayCommand(execute: () => LoguinUserCommand());

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            ForgetPassword = new RelayCommand(execute: () => ForgetThePaswordInfo());
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

            //SendEmail = new RelayCommand(SendEmailForPasswordBlank);
        }

        #region  Commands Implements

        public void LoguinUserCommand()
        {
            try
            {
                if (DDBBAccess.ValidateDBConnection())
                {
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
                else
                {
                    MessageBox.Show(GeneralMessages.ContactAdminMessage, GeneralMessages.InitApp, MessageBoxButton.OK, MessageBoxImage.Stop, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                }
            }
            catch (Exception)
            {
                //TODO: Mensaje de error por Exception.
                MessageBox.Show(GeneralMessages.ContactAdminMessage, GeneralMessages.LoginTitle, MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                //throw ex; ver si hace fata mostrar mensaje de Error con Message box Sencillo.
            }
        }

        private async Task PostLogAction(bool isLog)
        {
            if (isLog)
            {
                try
                {
                    messageDialogBoxViewModel = new MessageDialogBoxViewModel(GeneralMessages.LoginTitle, AccountMessages.CorrectCredentials);

                    await DI.DI.ViewModelApplication.ShowModalPage(ApplicationPage.MessageDialogBox, messageDialogBoxViewModel);

                    //SE PRUEBA LANZAR PRIMERO EN EL MAIN Y LUEGO DESDE AQUI

                    //Loggin Successfuly & Open Main Page
                    applicationViewModel.HandleSuccessfulLogin();                    
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                    //TODO: Mensaje de error al Abrir Main.
                    MessageBox.Show(GeneralMessages.ContactAdminMessage, GeneralMessages.LoginTitle, MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                }
            }
            else
            {
                try
                {
                    //Credenciales incorrectas
                    messageDialogBoxViewModel = new MessageDialogBoxViewModel(GeneralMessages.LoginTitle, AccountMessages.WrongCredentials);

                    await DI.DI.ViewModelApplication.ShowModalPage(ApplicationPage.MessageDialogBox, messageDialogBoxViewModel);
                }
                catch (Exception){}
            }
        }

        private async Task ForgetThePaswordInfo()
        {
            try
            {
                var messageContact = string.Concat(AccountMessages.ForgetPassMessage, AccountMessages.AdminInfo);

                //Credenciales incorrectas
                messageDialogBoxViewModel = new MessageDialogBoxViewModel(GeneralMessages.LoginTitle, messageContact);

                await DI.DI.ViewModelApplication.ShowModalPage(ApplicationPage.MessageDialogBox, messageDialogBoxViewModel);
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

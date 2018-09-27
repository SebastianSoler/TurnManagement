using System;
using System.Collections.Generic;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using TurnManagement.App_Turn.ViewModel.Application;
using TurnManagement.App_Turn.ViewModel.Base;
using TurnManagement.Business.Interfaces.Services;
using TurnManagement.CrossCutting.Enumerations;
using TurnManagement.CrossCutting.Strings;
using TurnManagement.Domain.Entities;

namespace TurnManagement.App_Turn.ViewModel
{

    public class MainViewModel : BaseViewModel
    {
        private ApplicationViewModel applicationViewModel;

        #region Private Properties SERVICES

        private readonly IApplicationUserService applicationUserService;

        private readonly IProfessionalService professionalService;

        private readonly IPatientService patientService;

        private readonly ISpecialityService specialityService;

        //Private Collections
        private IEnumerable<Speciality> _specialityList;
        private IEnumerable<Patient> _patientList;
        private IEnumerable<Professional> _professionalList;

        #endregion

        #region Public Properties COLLECTIONS

        public IEnumerable<Patient> PatientList
        {
            get { return _patientList; }
            private set
            {
                _patientList = value;
                base.RaisePropertyChanged("PatientList");
            }
        }

        public IEnumerable<Professional> ProfessionalList 
        {
            get { return _professionalList; }
            private set
            {
                _professionalList = value;
                base.RaisePropertyChanged("ProfessionalList");
            }
        }

        public IEnumerable<Speciality> SpecialityList 
        {
            get { return _specialityList; }
            private set
            {
                _specialityList = value;
                base.RaisePropertyChanged("SpecialityList");
            }
        }

        public IEnumerable<string> HealtInsuranceList { get; private set; } = new List<string>() { "IOMA", "OSDE", "ART" };

        #endregion

        #region Public Properties 

        private Professional professional { get; set; }

        public string ProfessionalFilter { get; set; }

        public string NewSpecialityName { get;set; }

        public string txtSpecialitySearch { get; set; }

        public Speciality SelectedSpecialityItem { get; set; } = null;

        #endregion

        #region COMMANDS

        #region COMMANDS To Open Windows

        public RelayCommand NewTurnCommand { get; set; }

        public RelayCommand Patients { get; set; }

        public RelayCommand Professionals { get; set; }

        public RelayCommand Specialitys { get; set; }

        #endregion

        public RelayCommand Filter { get; set; }

        public RelayCommand AddNewSpecialityRC { get; set; }

        public RelayCommand AddNewPatientRC { get; set; }

        public RelayCommand DeleteSpecialityRC { get; set; }

        public RelayCommand ModifySpecialityRC { get; set; }

        #endregion

        public MainViewModel(
            IApplicationUserService applicationUserService, 
            IProfessionalService professionalService, 
            IPatientService patientService,
            ISpecialityService specialityService)
        {
            this.applicationUserService = applicationUserService;
            this.professionalService = professionalService;
            this.patientService = patientService;
            this.specialityService = specialityService;

            applicationViewModel = DI.DI.ViewModelApplication;

            RegisterRelayCommands();
            InitializerDataList();
        }

        private void RegisterRelayCommands()
        {
            // Commands to Open Windows
            NewTurnCommand = new RelayCommand(execute: () => AddNewTurn());
            Patients = new RelayCommand(execute: () => AdminPatients());
            Professionals = new RelayCommand(execute: () => AdminProfessional());
            Specialitys = new RelayCommand(execute: () => AdminSpecialitys());
            Filter = new RelayCommand(execute: () => ApplyFilter(ProfessionalFilter));

            //Actions Commands
            AddNewSpecialityRC = new RelayCommand(execute: () => AddNewSpeciality());
            AddNewPatientRC = new RelayCommand(execute: () => AddNewPatient());
            DeleteSpecialityRC = new RelayCommand(execute: () => DeleteSpeciality());
            ModifySpecialityRC = new RelayCommand(execute: () => ModifySpecialityAsync());
        }

        private void InitializerDataList()
        {
            ProfessionalList = professionalService.GetAll();
            PatientList = patientService.GetAll();
            SpecialityList = specialityService.GetAll();
        }

        #region Command Implementations

        private void AddNewTurn()
        {
            try
            {
                var resp = applicationViewModel.ShowModalPage(ApplicationPage.Turns, this);
            }
            catch (Exception)
            {
                //TODO: Mensaje de error al Abrir Dialog de nuevo Turno
                MessageBox.Show(GeneralMessages.ShowWindowsError, GeneralMessages.NewTurnTitle, MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void AdminPatients()
        {
            try
            {
                var resp = applicationViewModel.ShowModalPage(ApplicationPage.Patients, this);
            }
            catch (Exception)
            {
                MessageBox.Show(GeneralMessages.ShowWindowsError, GeneralMessages.PatientsManagerTittle, MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void AdminProfessional()
        {
            try
            {
                var resp = applicationViewModel.ShowModalPage(ApplicationPage.Professionals, this);
            }
            catch (Exception)
            {
                MessageBox.Show(GeneralMessages.ShowWindowsError, GeneralMessages.ProfessionalsManagerTittle, MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void AdminSpecialitys()
        {
            try
            {
                var resp = applicationViewModel.ShowModalPage(ApplicationPage.Specialitys, this);
            }
            catch (Exception)
            {
                MessageBox.Show(GeneralMessages.ShowWindowsError, GeneralMessages.SpecialitiesManagerTittle, MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void ApplyFilter(string value)
        {
            string test = ProfessionalFilter;

            Console.WriteLine(test);
        }

        #endregion

        #region ACTION COMMANDS

        private void AddNewSpeciality()
        {
            try
            {
                var newSpeciality = new Speciality() { Name = NewSpecialityName };

                specialityService.Add(newSpeciality);

                SpecialityList = specialityService.GetAll();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, GeneralMessages.SpecialitiesManagerTittle, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void DeleteSpeciality()
        {
            try
            {
                if (SelectedSpecialityItem != null)
                {
                    var specialityId = SelectedSpecialityItem.Id;
                    
                    var bodyMessage = string.Format(ValidationMessages.ConfirmDeleteSpeciality, SelectedSpecialityItem.Name);

                    var result = MessageBox.Show(bodyMessage, GeneralMessages.SpecialitiesManagerTittle, MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.OK);

                    if (result == MessageBoxResult.OK)
                    {
                        specialityService.Delete(specialityId);

                        SpecialityList = specialityService.GetAll();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, GeneralMessages.SpecialitiesManagerTittle, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private async void ModifySpecialityAsync()
        {
            try
            {
                if(SelectedSpecialityItem != null)
                {
                    var oldName = SelectedSpecialityItem.Name;

                    var inputBoxViewModel = new Dialogs.InputDialogBoxViewModel(oldName);

                    await DI.DI.ViewModelApplication.ShowModalPage(ApplicationPage.inputDialogBox, inputBoxViewModel);

                    if (!string.IsNullOrWhiteSpace(inputBoxViewModel.NewSpecialityName))
                    {
                        SelectedSpecialityItem.Name = inputBoxViewModel.NewSpecialityName;

                        specialityService.Update(SelectedSpecialityItem);

                        SpecialityList = specialityService.GetAll();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, GeneralMessages.SpecialitiesManagerTittle, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void AddNewPatient()
        {
            
        }

        #endregion
    }
}
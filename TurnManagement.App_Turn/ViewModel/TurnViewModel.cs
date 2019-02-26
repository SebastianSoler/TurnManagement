using System;
using System.Collections.Generic;
using System.ComponentModel;
using TurnManagement.App_Turn.ViewModel.Base;
using TurnManagement.Business.Interfaces.Services;
using TurnManagement.CrossCutting.Enumerations;
using TurnManagement.Domain.Entities;

namespace TurnManagement.App_Turn.ViewModel
{
    public class TurnViewModel : BaseViewModel
    {
        private ITurnService turnService;

        public Turn Turn { get; set; } = new Turn();

        private IEnumerable<Turn> _turnCollection;

        public IEnumerable<Turn> TurnCollection
        {
            get { return _turnCollection; }
            set
            {
                _turnCollection = value;
                base.RaisePropertyChanged("TurnCollection");
            }
        }

        public BindingList<Turn> turnBindingList { get; set; }

        public TurnViewModel(ITurnService turnService)
        {
            this.turnService = turnService;

            TurnCollection = turnService.GetAll();

            ///Inicializacion RelayCommands
            //InitNewTurnCommand = new RelayCommand(execute: () => InitNewTurn());
            //TurnsUpdatedCommand = new RelayCommand(execute: () => TurnsUpdated());

            turnBindingList = GetTurnEvents();
        }

        public void TurnsUpdated()
        {
            var sarasa = 1;
            sarasa++;
        }

        public void InitNewTurn()
        {
            //int i = 0 + 2;
            //args.Appointment.Reminders.Clear();
        }

        public static BindingList<Turn> GetTurnEvents()
        {
            BindingList<Turn> result = new BindingList<Turn>();

            result.Add(CreateTurn("sebastian" + " meeting", 2, 5));
            result.Add(CreateTurn("Juan" + " travel", 3, 6));
            result.Add(CreateTurn("Cosme" + " phone call", 4, 10));
            result.Add(CreateTurn("Fulanito" + " sarasa", 1, 1));

            return result;
        }

        static Turn CreateTurn(string subject, int status, int label)
        {
            Random Rnd = new Random();

            Turn apt = new Turn();
            apt.Comment = subject;
            int rangeInMinutes = 60 * 24;
            apt.StartDateTime = DateTime.Today.AddHours(8) + TimeSpan.FromMinutes(Rnd.Next(0, rangeInMinutes));
            apt.EndDateTime = apt.StartDateTime + TimeSpan.FromMinutes(Rnd.Next(0, rangeInMinutes / 4));
            apt.Status = (Status)status;
            apt.SpecialityId = label;

            return apt;
        }
    }
}

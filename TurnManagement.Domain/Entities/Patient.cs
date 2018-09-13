using System;
using System.Collections.Generic;

namespace TurnManagement.Domain.Entities
{
    public class Patient : BaseEntity
    {
        #region Properties

        public string Name { get; set; }

        public string SurnName { get; set; }

        public string Dni { get; set; }

        public string Genre { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public string HealthInsurance { get; set; }

        public string Plan { get; set; }

        public string Email { get; set; }

        public string CellPhone { get; set; }

        public string Phone { get; set; }

        public string Note { get; set; }

        public virtual IList<Turn> Turns { get; set; } = new List<Turn>();

        #endregion
    }
}

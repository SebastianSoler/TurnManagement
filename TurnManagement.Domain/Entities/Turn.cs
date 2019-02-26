using System;
using TurnManagement.CrossCutting.Enumerations;

namespace TurnManagement.Domain.Entities
{
    public class Turn : BaseEntity
    {
        #region Properties

        public int ProfessionalId { get; set; }

        public virtual Professional Professional { get; set; }

        public int SpecialityId { get; set; }

        public virtual Speciality Speciality { get; set; }

        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; }

        public string Subject { get; set;}

        public DateTime StartDateTime { get;  set; }

        public DateTime EndDateTime { get;  set; }

        public Status Status { get; set; }

        public double Discount { get; set; } = 0;

        public double Ammount { get; set; }

        public string Comment { get; set; }

        #endregion
    }
}

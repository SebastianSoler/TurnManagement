using System;

namespace TurnManagement.Domain.Entities
{
    public class Turn : BaseEntity
    {
        #region Properties

        public int ProfessionalId { get; set; }

        public virtual Professional Professional { get; set; }

        public int SpecialityId { get; set; }

        public virtual Speciality Specialty { get; set; }

        public DateTime Date { get;  set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public double Discount { get; set; } = 0;

        public double Ammount { get; set; }

        //Verificar si es necesario tener la clase completa o solo referenciar Ids

        #endregion

    }
}

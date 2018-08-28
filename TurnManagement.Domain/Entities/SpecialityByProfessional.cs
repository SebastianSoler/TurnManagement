namespace TurnManagement.Domain.Entities
{
    public class SpecialityByProfessional
    {
        #region Properties

        public int SpeialityId { get; set; }

        public virtual Speciality Specialty { get; set; }

        public int ProfessionalId { get; set; }

        public virtual Professional Professional { get; set; }

        public bool IsDeleted { get; set; }

        #endregion
    }
}

namespace TurnManagement.Domain.Entities
{
    public class Patient : BaseEntity//Hacer heredar de BasePerson
    {
        #region Properties

        public string IdPatient { get; set; }

        public string Name { get; set; }

        public string SurnName { get; set; }

        #endregion
    }
}

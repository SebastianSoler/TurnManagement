namespace TurnManagement.Domain.Entities
{
    public class ApplicationUser : BaseEntity
    {
        #region Properties

        public string UserName { get; set; }

        public string Password { get; set; }

        #endregion

    }
}

namespace TurnManagement.App_Turn.EntitiesVM
{
    public class ApplicationUserVM : BaseEntityVM
    {
        #region Model Property : UserName
        /// <summary>
        /// The <see cref="UserName" /> property's name.
        /// </summary>
        public const string UserNamePropertyName = "UserName";

        private string userName;

        /// <summary>
        /// Sets and gets the UserName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                Set(() => UserName, ref userName, value);
            }
        }


        #endregion

        #region Model Property : Password
        /// <summary>
        /// The <see cref="Password" /> property's name.
        /// </summary>
        public const string PasswordPropertyName = "Password";

        private string password;

        /// <summary>
        /// Sets and gets the Password property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                Set(() => Password, ref password, value);
            }
        }


        #endregion
    }
}

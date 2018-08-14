using GalaSoft.MvvmLight;

namespace TurnManagement.App_Turn.EntitiesVM
{
    public abstract class BaseEntityVM : ViewModelBase
    {
        #region Model Property : Id
        /// <summary>
        /// The <see cref="Id" /> property's name.
        /// </summary>
        public const string IdPropertyName = "Id";

        private int idBase;

        /// <summary>
        /// Sets and gets the Id property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Id
        {
            get
            {
                return idBase;
            }
            set
            {
                Set(() => Id, ref idBase, value);
            }
        }

        #endregion

        #region Model Property : IsDelete
        /// <summary>
        /// The <see cref="IsDelete" /> property's name.
        /// </summary>
        public const string IsDeletePropertyName = "IsDelete";

        private bool isDelete;

        /// <summary>
        /// Sets and gets the IsDelete property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsDelete
        {
            get
            {
                return isDelete;
            }
            set
            {
                Set(() => IsDelete, ref isDelete, value);
            }
        }


        #endregion
    }
}

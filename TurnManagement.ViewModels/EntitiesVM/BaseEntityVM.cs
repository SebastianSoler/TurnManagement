using System;
using GalaSoft.MvvmLight;

namespace TurnManagement.ViewModels.EntitiesVM
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

        #region Model Property : CreateDate
        /// <summary>
        /// The <see cref="CreateDate" /> property's name.
        /// </summary>
        public const string CreateDatePropertyName = "CreateDate";

        private DateTime createDate;

        /// <summary>
        /// Sets and gets the CreateDate property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime CreateDate
        {
            get
            {
                return createDate;
            }
            set
            {
                Set(() => CreateDate, ref createDate, value);
            }
        }


        #endregion

        #region Model Property : CreatedBy
        /// <summary>
        /// The <see cref="CreatedBy" /> property's name.
        /// </summary>
        public const string CreatedByPropertyName = "CreatedBy";

        private string createdBy;

        /// <summary>
        /// Sets and gets the CreatedBy property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string CreatedBy
        {
            get
            {
                return createdBy;
            }
            set
            {
                Set(() => CreatedBy, ref createdBy, value);
            }
        }


        #endregion

        #region Model Property : ModifiedDate
        /// <summary>
        /// The <see cref="ModifiedDate" /> property's name.
        /// </summary>
        public const string ModifiedDatePropertyName = "ModifiedDate";

        private DateTime? modifiedDate;

        /// <summary>
        /// Sets and gets the ModifiedDate property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime? ModifiedDate
        {
            get
            {
                return modifiedDate;
            }
            set
            {
                Set(() => ModifiedDate, ref modifiedDate, value);
            }
        }


        #endregion

        #region Model Property : ModifiedBy
        /// <summary>
        /// The <see cref="ModifiedBy" /> property's name.
        /// </summary>
        public const string ModifiedByPropertyName = "ModifiedBy";

        private string modifiedBy;

        /// <summary>
        /// Sets and gets the ModifiedBy property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string ModifiedBy
        {
            get
            {
                return modifiedBy;
            }
            set
            {
                Set(() => ModifiedBy, ref modifiedBy, value);
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

        //public int Id { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime? ModifiedDate { get; set; }
        //public string ModifiedBy { get; set; }
        //public bool IsDeleted { get; set; }
    }
}

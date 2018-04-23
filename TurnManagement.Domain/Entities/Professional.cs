using System;
using System.ComponentModel.DataAnnotations;

namespace TurnManagement.Domain.Entities
{
    public class Professional : BaseEntity //Hacer heredar de BasePerson
    {
        #region  Properties
        [Key]
        public string IdProfessional { get; set; }

        public string Name { get; set; }

        public string SurName{ get; set; }

        public string Dni { get; set; }

        public DateTime Date { get; set; }

        public string  Address { get; set; }

        public string Telphone { get; set; }

        #endregion
    }
}

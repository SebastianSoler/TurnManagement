﻿using System;
using System.Collections.Generic;

namespace TurnManagement.Domain.Entities
{
    public class Professional : BaseEntity
    {
        #region  Properties

        public string Name { get; set; }

        public string SurName{ get; set; }

        public string Dni { get; set; }

        public string Genre { get; set; }

        public string RegistrationNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string  Address { get; set; }

        public string CellPhone { get; set; }

        public string Phone { get; set; }

        public virtual IList<Specialty> Specialties { get; set; } = new List<Specialty>();

        #endregion
    }
}
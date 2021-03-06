﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Appointments.Domain.Entities
{
    public class ModelBase
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Date Created")]
        [HiddenInput(DisplayValue = false)]
        public DateTime? DateCreated { get; set; }

        [Display(Name = "Date Updated")]
        [HiddenInput(DisplayValue = false)]
        public DateTime? DateUpdated { get; set; }

        [Display(Name = "Created By")]
        [HiddenInput(DisplayValue = false)]
        public string CreatedBy { get; set; }

        [Display(Name = "Updated By")]
        [HiddenInput(DisplayValue = false)]
        public string UpdatedBy { get; set; }

        [Display(Name = "Status")]
        [HiddenInput(DisplayValue = false)]
        public bool IsDeleted { get; set; }

        [Display(Name = "Date Status Changed")]
        [HiddenInput(DisplayValue = false)]
        public DateTime? DateDeleted { get; set; }

        [Display(Name = "Status Changed By")]
        [HiddenInput(DisplayValue = false)]
        public string DeletedBy { get; set; }

        //[HiddenInput(DisplayValue = false)]
        //public string Name { get; set; }


    }
}

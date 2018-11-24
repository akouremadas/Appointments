using System;
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

        [HiddenInput(DisplayValue = false)]
        public DateTime DateCreated { get; set; }

        [HiddenInput(DisplayValue = false)]
        public DateTime DateUpdated { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string CreatedBy { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string UpdatedBy { get; set; }

        //[HiddenInput(DisplayValue = false)]
        //public string Name { get; set; }


    }
}

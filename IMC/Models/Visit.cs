using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMC.Models
{
    public class Visit
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="sorry,enter start date of the visit")]
        [DisplayName("start date ")]
        public DateTime FromDate { get; set; }

        [Required(ErrorMessage = "sorry,enter end date of the visit")]
        [DisplayName("end date")]
        public DateTime ToDate { get; set; }


        [ForeignKey("Doctor"),Required(ErrorMessage ="sorry,enter doctor's name")]
        [DisplayName("doctor's name")]
        public int DoctorId { get; set; }
        
        public virtual Doctor Doctor { get; set; }
    }
}
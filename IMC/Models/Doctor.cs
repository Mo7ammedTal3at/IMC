using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMC.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage ="sorry,enter docotr Name")]
        [DisplayName("docotr Name")]
        public string Name { get; set; }

        [DisplayName("doctor's phone number")]
        public string Phone { get; set; }


        [DisplayName("doctor's nationality")]
        public string Nationality { get; set; }


        [Required(ErrorMessage ="sorry,enter docotr's scient degree")]
        [DisplayName("scient degree")]
        public string ScientDegree { get; set; }

        [Required(ErrorMessage = "sorry, enter doctor's accurate degree")]
        [DisplayName("accurate degree")]
        public string AccurateSpecialty { get; set; }

        public bool IsSpecialist { get; set; }

        [Required(ErrorMessage ="sorry,select a clinic")]
        [DisplayName("clinic name")]
        [ForeignKey("Clinic")]
        public int ClinicId { get; set; }
        public virtual Clinic Clinic { get; set; }

        public int MyProperty { get; set; }

        public virtual List<DoctorCalendar> DoctorCalendars { get; set; }
        public virtual List<Visit> Visits { get; set; }

    }
}
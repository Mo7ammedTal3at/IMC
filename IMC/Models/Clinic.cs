using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMC.Models
{
    public class Clinic
    {
        public int Id { get; set; }
     
        [Required(ErrorMessage = "sorry,enter clinic name")]
        [DisplayName("clinic name")]
        public string Name { get; set; }


        [Required(ErrorMessage ="sorry,enter flower number")]
        [DisplayName("flower number")]
        public byte FlowerNumber { get; set; }
        public virtual List<PatientReservation> PatientReservations { get; set; }
        public virtual List<Doctor> Doctors { get; set; }
    }
}
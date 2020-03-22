using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMC.Models
{
    public class PatientReservation
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage ="sorry,enter patient name to register your application")]
        [DisplayName("patient name")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "sorry,enter patient phone number to complete your applicaiton")]
        [DisplayName("sorry,enter phone number to complete your application")]
        public string Phone { get; set; }



        [Required(ErrorMessage ="sorry,enter the complaint of the patient ")]
        [StringLength(100, ErrorMessage = "sorry complaint can't be over 100 character")]
        [DisplayName("patient's complaint")]
        public string Complaint { get; set; }
        
        
        [Required(ErrorMessage = "sorry,select a clinic")]
        [ForeignKey("Clinic")]
        [DisplayName("clinic name")]            
        public int ClinicId { get; set; }

        
        [ForeignKey("Doctor")]
        [DisplayName("doctor name")]
        public int? SpecialitId { get; set; }

        public virtual Clinic Clinic { get; set; }
        public virtual Doctor Doctor { get; set; }


       
    }
}
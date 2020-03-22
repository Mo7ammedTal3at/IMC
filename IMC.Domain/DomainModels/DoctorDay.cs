using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMC.Domain.DomainModels
{
    public class DoctorDay
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "sorry,enter day name")]
        [DisplayName("day name")]
        public string DayName { get; set; }
        public virtual List<DoctorCalendar> DoctorCalendars { get; set; }

    }
}

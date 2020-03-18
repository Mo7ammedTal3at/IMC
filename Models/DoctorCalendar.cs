using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DoctorCalendar
    {
        [Key]
        [Column(Order = 1)]
        public int DoctorId { get; set; }
        
        [Key]
        [Column(Order = 2)]
        public int DoctorDayId { get; set; }       

        public byte FromHour { get; set; }
        public byte ToHour { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual DoctorDay DoctorDay { get; set; }
    }
}

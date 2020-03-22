using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMC.Domain.DomainModels
{
    public class IMCDbContext : DbContext
    {
        public IMCDbContext()
          : base("DefaultConnection")
        {
        }

        public static IMCDbContext Create()
        {
            return new IMCDbContext();
        }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<PatientReservation> PatientReservations { get; set; }
        public DbSet<DoctorDay> DoctorDays { get; set; }
        public DbSet<DoctorCalendar> DoctorCalendars { get; set; }
    }
}

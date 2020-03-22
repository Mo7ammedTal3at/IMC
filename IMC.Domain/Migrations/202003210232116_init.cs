namespace IMC.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clinics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        FlowerNumber = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Phone = c.String(),
                        Nationality = c.String(),
                        ScientDegree = c.String(nullable: false),
                        AccurateSpecialty = c.String(nullable: false),
                        IsSpecialist = c.Boolean(nullable: false),
                        ClinicId = c.Int(nullable: false),
                        MyProperty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clinics", t => t.ClinicId, cascadeDelete: true)
                .Index(t => t.ClinicId);
            
            CreateTable(
                "dbo.DoctorCalendars",
                c => new
                    {
                        DoctorId = c.Int(nullable: false),
                        DoctorDayId = c.Int(nullable: false),
                        FromHour = c.Byte(nullable: false),
                        ToHour = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => new { t.DoctorId, t.DoctorDayId })
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.DoctorDays", t => t.DoctorDayId, cascadeDelete: true)
                .Index(t => t.DoctorId)
                .Index(t => t.DoctorDayId);
            
            CreateTable(
                "dbo.DoctorDays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DayName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Visits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FromDate = c.DateTime(nullable: false),
                        ToDate = c.DateTime(nullable: false),
                        DoctorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.PatientReservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Complaint = c.String(nullable: false, maxLength: 100),
                        ClinicId = c.Int(nullable: false),
                        SpecialitId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clinics", t => t.ClinicId, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.SpecialitId)
                .Index(t => t.ClinicId)
                .Index(t => t.SpecialitId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientReservations", "SpecialitId", "dbo.Doctors");
            DropForeignKey("dbo.PatientReservations", "ClinicId", "dbo.Clinics");
            DropForeignKey("dbo.Visits", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.DoctorCalendars", "DoctorDayId", "dbo.DoctorDays");
            DropForeignKey("dbo.DoctorCalendars", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Doctors", "ClinicId", "dbo.Clinics");
            DropIndex("dbo.PatientReservations", new[] { "SpecialitId" });
            DropIndex("dbo.PatientReservations", new[] { "ClinicId" });
            DropIndex("dbo.Visits", new[] { "DoctorId" });
            DropIndex("dbo.DoctorCalendars", new[] { "DoctorDayId" });
            DropIndex("dbo.DoctorCalendars", new[] { "DoctorId" });
            DropIndex("dbo.Doctors", new[] { "ClinicId" });
            DropTable("dbo.PatientReservations");
            DropTable("dbo.Visits");
            DropTable("dbo.DoctorDays");
            DropTable("dbo.DoctorCalendars");
            DropTable("dbo.Doctors");
            DropTable("dbo.Clinics");
        }
    }
}

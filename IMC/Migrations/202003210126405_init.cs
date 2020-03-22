namespace IMC.Migrations
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
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PatientReservations", "SpecialitId", "dbo.Doctors");
            DropForeignKey("dbo.PatientReservations", "ClinicId", "dbo.Clinics");
            DropForeignKey("dbo.Visits", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.DoctorCalendars", "DoctorDayId", "dbo.DoctorDays");
            DropForeignKey("dbo.DoctorCalendars", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Doctors", "ClinicId", "dbo.Clinics");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PatientReservations", new[] { "SpecialitId" });
            DropIndex("dbo.PatientReservations", new[] { "ClinicId" });
            DropIndex("dbo.Visits", new[] { "DoctorId" });
            DropIndex("dbo.DoctorCalendars", new[] { "DoctorDayId" });
            DropIndex("dbo.DoctorCalendars", new[] { "DoctorId" });
            DropIndex("dbo.Doctors", new[] { "ClinicId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PatientReservations");
            DropTable("dbo.Visits");
            DropTable("dbo.DoctorDays");
            DropTable("dbo.DoctorCalendars");
            DropTable("dbo.Doctors");
            DropTable("dbo.Clinics");
        }
    }
}

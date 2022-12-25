namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateScheduleTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "DoctorID", "dbo.Doctors");
            DropIndex("dbo.Appointments", new[] { "DoctorID" });
            CreateTable(
                "dbo.DoctorSchedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoctorID = c.Int(nullable: false),
                        DoctorName = c.String(nullable: false, maxLength: 100),
                        Qualification = c.String(nullable: false, maxLength: 100),
                        CheckUpTimeStart = c.DateTime(nullable: false),
                        CheckUpTimeEnd = c.DateTime(nullable: false),
                        WeekDay = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorID, cascadeDelete: true)
                .Index(t => t.DoctorID);
            
            AddColumn("dbo.Appointments", "ScheduleID", c => c.Int(nullable: false));
            AddColumn("dbo.Appointments", "DoctorQualification", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.PatientCheckUps", "AppointMentID", c => c.Int(nullable: false));
            CreateIndex("dbo.Appointments", "ScheduleID");
            CreateIndex("dbo.PatientCheckUps", "AppointMentID");
            AddForeignKey("dbo.Appointments", "ScheduleID", "dbo.DoctorSchedules", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PatientCheckUps", "AppointMentID", "dbo.Appointments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientCheckUps", "AppointMentID", "dbo.Appointments");
            DropForeignKey("dbo.Appointments", "ScheduleID", "dbo.DoctorSchedules");
            DropForeignKey("dbo.DoctorSchedules", "DoctorID", "dbo.Doctors");
            DropIndex("dbo.PatientCheckUps", new[] { "AppointMentID" });
            DropIndex("dbo.DoctorSchedules", new[] { "DoctorID" });
            DropIndex("dbo.Appointments", new[] { "ScheduleID" });
            DropColumn("dbo.PatientCheckUps", "AppointMentID");
            DropColumn("dbo.Appointments", "DoctorQualification");
            DropColumn("dbo.Appointments", "ScheduleID");
            DropTable("dbo.DoctorSchedules");
            CreateIndex("dbo.Appointments", "DoctorID");
            AddForeignKey("dbo.Appointments", "DoctorID", "dbo.Doctors", "ID", cascadeDelete: true);
        }
    }
}

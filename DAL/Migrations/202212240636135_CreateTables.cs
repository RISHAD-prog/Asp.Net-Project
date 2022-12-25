namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTables : DbMigration
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
            
            CreateTable(
                "dbo.NoticeBoards",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Appointments", "ScheduleID", c => c.Int(nullable: false));
            AddColumn("dbo.Beds", "Status", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Admins", "Phone", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Admins", "Address", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Tokens", "Type", c => c.String(nullable: false));
            AlterColumn("dbo.BedAllotments", "DischargeDate", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Appointments", "ScheduleID");
            AddForeignKey("dbo.Appointments", "ScheduleID", "dbo.DoctorSchedules", "Id", cascadeDelete: true);
            DropColumn("dbo.Admins", "Location");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "Location", c => c.String(nullable: false, maxLength: 50));
            DropForeignKey("dbo.Appointments", "ScheduleID", "dbo.DoctorSchedules");
            DropForeignKey("dbo.DoctorSchedules", "DoctorID", "dbo.Doctors");
            DropIndex("dbo.DoctorSchedules", new[] { "DoctorID" });
            DropIndex("dbo.Appointments", new[] { "ScheduleID" });
            AlterColumn("dbo.BedAllotments", "DischargeDate", c => c.DateTime());
            DropColumn("dbo.Tokens", "Type");
            DropColumn("dbo.Admins", "Address");
            DropColumn("dbo.Admins", "Phone");
            DropColumn("dbo.Beds", "Status");
            DropColumn("dbo.Appointments", "ScheduleID");
            DropTable("dbo.NoticeBoards");
            DropTable("dbo.DoctorSchedules");
            CreateIndex("dbo.Appointments", "DoctorID");
            AddForeignKey("dbo.Appointments", "DoctorID", "dbo.Doctors", "ID", cascadeDelete: true);
        }
    }
}

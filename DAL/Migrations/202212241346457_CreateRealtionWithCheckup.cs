namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateRealtionWithCheckup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PatientCheckUps", "AppointmentID", c => c.Int(nullable: false));
            CreateIndex("dbo.PatientCheckUps", "AppointmentID");
            AddForeignKey("dbo.PatientCheckUps", "AppointmentID", "dbo.Appointments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientCheckUps", "AppointmentID", "dbo.Appointments");
            DropIndex("dbo.PatientCheckUps", new[] { "AppointmentID" });
            DropColumn("dbo.PatientCheckUps", "AppointmentID");
        }
    }
}

namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_newColumn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DoctorSchedules", "WeekDay", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DoctorSchedules", "WeekDay", c => c.DateTime(nullable: false));
        }
    }
}

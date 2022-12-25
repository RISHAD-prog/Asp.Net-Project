namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Beds", "Status", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Beds", "Status");
        }
    }
}

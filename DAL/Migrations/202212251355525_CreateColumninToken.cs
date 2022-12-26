namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateColumninToken : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tokens", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Tokens", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tokens", "Email", c => c.String(nullable: false));
            DropColumn("dbo.Tokens", "Name");
        }
    }
}

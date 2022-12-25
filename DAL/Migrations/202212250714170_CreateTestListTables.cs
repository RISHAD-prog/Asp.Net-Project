namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTestListTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Labratories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientID = c.Int(nullable: false),
                        PatientName = c.String(nullable: false, maxLength: 50),
                        TestID = c.Int(nullable: false),
                        TestName = c.String(nullable: false, maxLength: 100),
                        TestFee = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientID, cascadeDelete: true)
                .ForeignKey("dbo.TestLists", t => t.TestID, cascadeDelete: true)
                .Index(t => t.PatientID)
                .Index(t => t.TestID);
            
            CreateTable(
                "dbo.TestLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TestName = c.String(nullable: false, maxLength: 100),
                        TestFee = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Patients", "Bill", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Labratories", "TestID", "dbo.TestLists");
            DropForeignKey("dbo.Labratories", "PatientID", "dbo.Patients");
            DropIndex("dbo.Labratories", new[] { "TestID" });
            DropIndex("dbo.Labratories", new[] { "PatientID" });
            DropColumn("dbo.Patients", "Bill");
            DropTable("dbo.TestLists");
            DropTable("dbo.Labratories");
        }
    }
}

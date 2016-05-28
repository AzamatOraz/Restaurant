namespace FinalExamBackEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Mail = c.String(),
                        Accumulation = c.Int(nullable: false),
                        Manager_ID = c.Int(nullable: false),
                        Manager_ID1 = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Staff", t => t.Manager_ID1)
                .Index(t => t.Manager_ID1);
            
            CreateTable(
                "dbo.Staff",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Mail = c.String(),
                        HireDate = c.DateTime(nullable: false),
                        Manager_ID = c.Int(nullable: false),
                        Department_ID = c.Int(nullable: false),
                        Department_ID1 = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Department", t => t.Department_ID1)
                .Index(t => t.Department_ID1);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DepName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FoodType = c.String(),
                        Manager_ID = c.Int(nullable: false),
                        Manager_ID1 = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Staff", t => t.Manager_ID1)
                .Index(t => t.Manager_ID1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menu", "Manager_ID1", "dbo.Staff");
            DropForeignKey("dbo.Client", "Manager_ID1", "dbo.Staff");
            DropForeignKey("dbo.Staff", "Department_ID1", "dbo.Department");
            DropIndex("dbo.Menu", new[] { "Manager_ID1" });
            DropIndex("dbo.Staff", new[] { "Department_ID1" });
            DropIndex("dbo.Client", new[] { "Manager_ID1" });
            DropTable("dbo.Menu");
            DropTable("dbo.Department");
            DropTable("dbo.Staff");
            DropTable("dbo.Client");
        }
    }
}

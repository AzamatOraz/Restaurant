namespace FinalExamBackEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComplexDataModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Client", "Password", c => c.String(nullable: false));
            AddColumn("dbo.Staff", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Client", "Mail", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Staff", "Mail", c => c.String(nullable: false, maxLength: 20));
            CreateIndex("dbo.Client", "Mail", unique: true);
            CreateIndex("dbo.Staff", "Mail", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Staff", new[] { "Mail" });
            DropIndex("dbo.Client", new[] { "Mail" });
            AlterColumn("dbo.Staff", "Mail", c => c.String());
            AlterColumn("dbo.Client", "Mail", c => c.String(nullable: false));
            DropColumn("dbo.Staff", "Password");
            DropColumn("dbo.Client", "Password");
        }
    }
}

namespace uniManageSys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class phiraddd : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Student", "wel");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Student", "wel", c => c.Int(nullable: false));
        }
    }
}

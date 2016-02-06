namespace uniManageSys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class phiradd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "wel", c => c.Int(nullable: false));
            //DropColumn("dbo.Student", "younas");
            DropColumn("dbo.Student", "hehehe");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Student", "hehehe", c => c.String());
            AddColumn("dbo.Student", "younas", c => c.Int(nullable: false));
            DropColumn("dbo.Student", "wel");
        }
    }
}

namespace uniManageSys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addanother : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "hehehe", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student", "hehehe");
        }
    }
}

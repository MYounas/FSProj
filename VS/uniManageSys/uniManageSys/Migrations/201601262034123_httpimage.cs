namespace uniManageSys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class httpimage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student", "ImageUrl");
        }
    }
}

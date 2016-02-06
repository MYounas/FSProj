namespace uniManageSys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stringimage : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Student", "ImageUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Student", "ImageUrl", c => c.String());
        }
    }
}

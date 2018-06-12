namespace DMNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnewcolumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meetings", "image", c => c.String());
            AddColumn("dbo.Projects", "destription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "destription");
            DropColumn("dbo.Meetings", "image");
        }
    }
}

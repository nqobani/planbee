namespace DMNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zzzzzz : DbMigration
    {
        public override void Up()
        {
            DropColumn("Meetings", "imagebyte");
        }
        
        public override void Down()
        {
        }
    }
}

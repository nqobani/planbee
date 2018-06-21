namespace DMNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add : DbMigration
    {
        public override void Up()
        {
            AddColumn("Meetings", "imagePath", c => c.String());
        }
        
        public override void Down()
        {
        }
    }
}

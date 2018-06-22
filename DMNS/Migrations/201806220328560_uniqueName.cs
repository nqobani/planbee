namespace DMNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uniqueName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "username", c => c.String(maxLength: 450));
            CreateIndex("dbo.Users", "username", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "username" });
            AlterColumn("dbo.Users", "username", c => c.String());
        }
    }
}

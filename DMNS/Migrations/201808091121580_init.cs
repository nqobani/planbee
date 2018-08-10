namespace DMNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SharedMeetings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        sharedBy = c.Int(nullable: false),
                        sharedTo = c.Int(nullable: false),
                        meetingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.SharedProjects",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        sharedBy = c.Int(nullable: false),
                        sharedTo = c.Int(nullable: false),
                        projectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Meetings", "imagePath", c => c.String());
            AddColumn("dbo.Projects", "destription", c => c.String());
            AddColumn("dbo.Users", "code", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "confirmed", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Users", "username", c => c.String(maxLength: 450));
            CreateIndex("dbo.Users", "username", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "username" });
            AlterColumn("dbo.Users", "username", c => c.String());
            DropColumn("dbo.Users", "confirmed");
            DropColumn("dbo.Users", "code");
            DropColumn("dbo.Projects", "destription");
            DropColumn("dbo.Meetings", "imagePath");
            DropTable("dbo.SharedProjects");
            DropTable("dbo.SharedMeetings");
        }
    }
}

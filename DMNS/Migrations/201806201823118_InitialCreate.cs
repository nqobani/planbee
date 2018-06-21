namespace DMNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Meetings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        projectId = c.Int(nullable: false),
                        name = c.String(),
                        notes = c.String(),
                        imagebyte = c.Binary(),
                        createdAt = c.DateTime(nullable: false),
                        decisions = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        userId = c.Int(nullable: false),
                        name = c.String(),
                        destription = c.String(),
                        createdAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
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
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        password = c.String(),
                        email = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.SharedProjects");
            DropTable("dbo.SharedMeetings");
            DropTable("dbo.Projects");
            DropTable("dbo.Meetings");
        }
    }
}

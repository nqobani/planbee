namespace DMNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class us : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SharedProjects");
            DropTable("dbo.SharedMeetings");
        }
    }
}

namespace cq.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ScheduledAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReviewAttendees",
                c => new
                    {
                        Review_Id = c.Int(nullable: false),
                        Attendee_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Review_Id, t.Attendee_Id })
                .ForeignKey("dbo.Reviews", t => t.Review_Id, cascadeDelete: true)
                .ForeignKey("dbo.Attendees", t => t.Attendee_Id, cascadeDelete: true)
                .Index(t => t.Review_Id)
                .Index(t => t.Attendee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReviewAttendees", "Attendee_Id", "dbo.Attendees");
            DropForeignKey("dbo.ReviewAttendees", "Review_Id", "dbo.Reviews");
            DropIndex("dbo.ReviewAttendees", new[] { "Attendee_Id" });
            DropIndex("dbo.ReviewAttendees", new[] { "Review_Id" });
            DropTable("dbo.ReviewAttendees");
            DropTable("dbo.Reviews");
            DropTable("dbo.Attendees");
        }
    }
}

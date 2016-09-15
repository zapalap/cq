namespace cq.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SerializedCommands : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SerializedCommands",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Json = c.String(),
                        StoredAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SerializedCommands");
        }
    }
}

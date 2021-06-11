namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initiall : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Albums", "SongStyleId", "dbo.SongStyles");
            DropForeignKey("dbo.Albums", "Song_Id", "dbo.Songs");
            DropForeignKey("dbo.Songs", "Album_Id", "dbo.Albums");
            DropIndex("dbo.Albums", new[] { "SongStyleId" });
            DropIndex("dbo.Albums", new[] { "Song_Id" });
            DropIndex("dbo.Songs", new[] { "Album_Id" });
            DropColumn("dbo.Songs", "Album_Id");
            DropTable("dbo.Albums");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SongStyleId = c.Int(nullable: false),
                        Song_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Songs", "Album_Id", c => c.Int());
            CreateIndex("dbo.Songs", "Album_Id");
            CreateIndex("dbo.Albums", "Song_Id");
            CreateIndex("dbo.Albums", "SongStyleId");
            AddForeignKey("dbo.Songs", "Album_Id", "dbo.Albums", "Id");
            AddForeignKey("dbo.Albums", "Song_Id", "dbo.Songs", "Id");
            AddForeignKey("dbo.Albums", "SongStyleId", "dbo.SongStyles", "Id", cascadeDelete: true);
        }
    }
}

namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Singers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SongStyleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SongStyles", t => t.SongStyleId, cascadeDelete: true)
                .Index(t => t.SongStyleId);
            
            CreateTable(
                "dbo.SongStyles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        songName = c.String(),
                        Singer = c.String(),
                        Year = c.Int(nullable: false),
                        SongStyleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SongStyles", t => t.SongStyleId, cascadeDelete: true)
                .Index(t => t.SongStyleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        isAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Songs", "SongStyleId", "dbo.SongStyles");
            DropForeignKey("dbo.Singers", "SongStyleId", "dbo.SongStyles");
            DropIndex("dbo.Songs", new[] { "SongStyleId" });
            DropIndex("dbo.Singers", new[] { "SongStyleId" });
            DropTable("dbo.Users");
            DropTable("dbo.Songs");
            DropTable("dbo.SongStyles");
            DropTable("dbo.Singers");
        }
    }
}

namespace ChessDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        blackPlayer = c.String(nullable: false, maxLength: 30),
                        whitePlayer = c.String(nullable: false, maxLength: 30),
                        date = c.DateTime(nullable: false),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Moves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        gameId = c.Int(nullable: false),
                        moveNumber = c.Int(nullable: false),
                        whitePlyId = c.Int(nullable: false),
                        blackPlyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Plies", t => t.blackPlyId, cascadeDelete: true)
                .ForeignKey("dbo.Games", t => t.gameId, cascadeDelete: true)
                .ForeignKey("dbo.Plies", t => t.whitePlyId, cascadeDelete: false)
                .Index(t => t.gameId)
                .Index(t => t.whitePlyId)
                .Index(t => t.blackPlyId);
            
            CreateTable(
                "dbo.Plies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        moveId = c.Int(nullable: false),
                        startSqRow = c.Int(nullable: false),
                        startSqColumn = c.Int(nullable: false),
                        endSqRow = c.Int(nullable: false),
                        endSqColumn = c.Int(nullable: false),
                        color = c.String(nullable: false),
                        plyAnnotation = c.String(nullable: false),
                        moveNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Moves", t => t.moveId, cascadeDelete: false)
                .Index(t => t.moveId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Moves", "whitePlyId", "dbo.Plies");
            DropForeignKey("dbo.Moves", "gameId", "dbo.Games");
            DropForeignKey("dbo.Moves", "blackPlyId", "dbo.Plies");
            DropForeignKey("dbo.Plies", "moveId", "dbo.Moves");
            DropIndex("dbo.Plies", new[] { "moveId" });
            DropIndex("dbo.Moves", new[] { "blackPlyId" });
            DropIndex("dbo.Moves", new[] { "whitePlyId" });
            DropIndex("dbo.Moves", new[] { "gameId" });
            DropTable("dbo.Plies");
            DropTable("dbo.Moves");
            DropTable("dbo.Games");
        }
    }
}

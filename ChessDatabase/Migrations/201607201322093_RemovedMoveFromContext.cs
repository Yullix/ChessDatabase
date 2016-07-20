namespace ChessDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedMoveFromContext : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Plies", "moveId", "dbo.Moves");
            DropForeignKey("dbo.Moves", "blackPlyId", "dbo.Plies");
            DropForeignKey("dbo.Moves", "gameId", "dbo.Games");
            DropForeignKey("dbo.Moves", "whitePlyId", "dbo.Plies");
            DropForeignKey("dbo.Games", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Games", new[] { "CategoryId" });
            DropIndex("dbo.Moves", new[] { "gameId" });
            DropIndex("dbo.Moves", new[] { "whitePlyId" });
            DropIndex("dbo.Moves", new[] { "blackPlyId" });
            DropIndex("dbo.Plies", new[] { "moveId" });
            AddColumn("dbo.Plies", "gameId", c => c.Int(nullable: false));
            CreateIndex("dbo.Games", "categoryId");
            CreateIndex("dbo.Plies", "gameId");
            AddForeignKey("dbo.Plies", "gameId", "dbo.Games", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Games", "categoryId", "dbo.Categories", "Id");
            DropColumn("dbo.Plies", "moveId");
            DropTable("dbo.Moves");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Plies", "moveId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Games", "categoryId", "dbo.Categories");
            DropForeignKey("dbo.Plies", "gameId", "dbo.Games");
            DropIndex("dbo.Plies", new[] { "gameId" });
            DropIndex("dbo.Games", new[] { "categoryId" });
            DropColumn("dbo.Plies", "gameId");
            CreateIndex("dbo.Plies", "moveId");
            CreateIndex("dbo.Moves", "blackPlyId");
            CreateIndex("dbo.Moves", "whitePlyId");
            CreateIndex("dbo.Moves", "gameId");
            CreateIndex("dbo.Games", "CategoryId");
            AddForeignKey("dbo.Games", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Moves", "whitePlyId", "dbo.Plies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Moves", "gameId", "dbo.Games", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Moves", "blackPlyId", "dbo.Plies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Plies", "moveId", "dbo.Moves", "Id", cascadeDelete: true);
        }
    }
}

namespace ChessDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPlayerForeignKeyToMatch : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "blackPlayerId", c => c.Int());
            AddColumn("dbo.Games", "whitePlayerId", c => c.Int());
            CreateIndex("dbo.Games", "blackPlayerId");
            CreateIndex("dbo.Games", "whitePlayerId");
            AddForeignKey("dbo.Games", "blackPlayerId", "dbo.Players", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Games", "whitePlayerId", "dbo.Players", "Id", cascadeDelete: false);
            DropColumn("dbo.Games", "blackPlayer");
            DropColumn("dbo.Games", "whitePlayer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "whitePlayer", c => c.String(maxLength: 30));
            AddColumn("dbo.Games", "blackPlayer", c => c.String(maxLength: 30));
            DropForeignKey("dbo.Games", "whitePlayerId", "dbo.Players");
            DropForeignKey("dbo.Games", "blackPlayerId", "dbo.Players");
            DropIndex("dbo.Games", new[] { "whitePlayerId" });
            DropIndex("dbo.Games", new[] { "blackPlayerId" });
            DropColumn("dbo.Games", "whitePlayerId");
            DropColumn("dbo.Games", "blackPlayerId");
        }
    }
}

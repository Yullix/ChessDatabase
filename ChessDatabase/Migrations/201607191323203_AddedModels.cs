namespace ChessDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        rating = c.Int(nullable: false),
                        name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tournaments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        startDate = c.DateTime(nullable: false),
                        endDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Games", "name1", c => c.String());
            AddColumn("dbo.Games", "openingMove", c => c.String());
            AddColumn("dbo.Games", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Games", "Player_Id", c => c.Int());
            AddColumn("dbo.Games", "Tournament_Id", c => c.Int());
            AlterColumn("dbo.Games", "blackPlayer", c => c.String(maxLength: 30));
            AlterColumn("dbo.Games", "whitePlayer", c => c.String(maxLength: 30));
            CreateIndex("dbo.Games", "Player_Id");
            CreateIndex("dbo.Games", "Tournament_Id");
            AddForeignKey("dbo.Games", "Player_Id", "dbo.Players", "Id");
            AddForeignKey("dbo.Games", "Tournament_Id", "dbo.Tournaments", "Id");
            DropColumn("dbo.Games", "date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "date", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Games", "Tournament_Id", "dbo.Tournaments");
            DropForeignKey("dbo.Games", "Player_Id", "dbo.Players");
            DropIndex("dbo.Games", new[] { "Tournament_Id" });
            DropIndex("dbo.Games", new[] { "Player_Id" });
            AlterColumn("dbo.Games", "whitePlayer", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Games", "blackPlayer", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.Games", "Tournament_Id");
            DropColumn("dbo.Games", "Player_Id");
            DropColumn("dbo.Games", "Discriminator");
            DropColumn("dbo.Games", "openingMove");
            DropColumn("dbo.Games", "name1");
            DropTable("dbo.Tournaments");
            DropTable("dbo.Players");
        }
    }
}

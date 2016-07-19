namespace ChessDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedGameName : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Games", "name1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "name1", c => c.String());
        }
    }
}

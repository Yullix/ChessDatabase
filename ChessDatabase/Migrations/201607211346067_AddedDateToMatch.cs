namespace ChessDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDateToMatch : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "date", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "date");
        }
    }
}

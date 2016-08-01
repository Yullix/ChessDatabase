namespace ChessDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCapturedPiecePly : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Plies", "capturedPieceAnnotation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Plies", "capturedPieceAnnotation");
        }
    }
}

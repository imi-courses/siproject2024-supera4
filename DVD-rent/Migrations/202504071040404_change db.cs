namespace DVD_rent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedb : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.MovieDVDs", name: "Movie_Id", newName: "MoiveID");
            RenameColumn(table: "dbo.MovieDVDs", name: "DVD_Id", newName: "DVDID");
            RenameIndex(table: "dbo.MovieDVDs", name: "IX_DVD_Id", newName: "IX_DVDID");
            RenameIndex(table: "dbo.MovieDVDs", name: "IX_Movie_Id", newName: "IX_MoiveID");
            DropPrimaryKey("dbo.MovieDVDs");
            AddPrimaryKey("dbo.MovieDVDs", new[] { "DVDID", "MoiveID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.MovieDVDs");
            AddPrimaryKey("dbo.MovieDVDs", new[] { "Movie_Id", "DVD_Id" });
            RenameIndex(table: "dbo.MovieDVDs", name: "IX_MoiveID", newName: "IX_Movie_Id");
            RenameIndex(table: "dbo.MovieDVDs", name: "IX_DVDID", newName: "IX_DVD_Id");
            RenameColumn(table: "dbo.MovieDVDs", name: "DVDID", newName: "DVD_Id");
            RenameColumn(table: "dbo.MovieDVDs", name: "MoiveID", newName: "Movie_Id");
        }
    }
}

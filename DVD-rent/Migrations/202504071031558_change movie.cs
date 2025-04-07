namespace DVD_rent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changemovie : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "DVD_Id", "dbo.DVDs");
            DropIndex("dbo.Movies", new[] { "DVD_Id" });
            CreateTable(
                "dbo.MovieDVDs",
                c => new
                    {
                        Movie_Id = c.Int(nullable: false),
                        DVD_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_Id, t.DVD_Id })
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .ForeignKey("dbo.DVDs", t => t.DVD_Id, cascadeDelete: true)
                .Index(t => t.Movie_Id)
                .Index(t => t.DVD_Id);
            
            DropColumn("dbo.Movies", "DVD_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "DVD_Id", c => c.Int());
            DropForeignKey("dbo.MovieDVDs", "DVD_Id", "dbo.DVDs");
            DropForeignKey("dbo.MovieDVDs", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.MovieDVDs", new[] { "DVD_Id" });
            DropIndex("dbo.MovieDVDs", new[] { "Movie_Id" });
            DropTable("dbo.MovieDVDs");
            CreateIndex("dbo.Movies", "DVD_Id");
            AddForeignKey("dbo.Movies", "DVD_Id", "dbo.DVDs", "Id");
        }
    }
}

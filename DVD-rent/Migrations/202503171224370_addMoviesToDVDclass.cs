namespace DVD_rent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMoviesToDVDclass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "DVD_Id", c => c.Int());
            CreateIndex("dbo.Movies", "DVD_Id");
            AddForeignKey("dbo.Movies", "DVD_Id", "dbo.DVDs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "DVD_Id", "dbo.DVDs");
            DropIndex("dbo.Movies", new[] { "DVD_Id" });
            DropColumn("dbo.Movies", "DVD_Id");
        }
    }
}

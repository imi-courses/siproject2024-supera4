namespace DVD_rent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class manytomanyrentdvd : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DVDs", "RentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DVDs", "RentId", c => c.Int());
        }
    }
}

namespace DVD_rent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clientnumber : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "PhoneNumber", c => c.Int(nullable: false));
        }
    }
}

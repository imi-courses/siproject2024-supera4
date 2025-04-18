namespace DVD_rent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rents", "PledgeId", "dbo.Pledges");
            DropForeignKey("dbo.DVDs", "Rent_PledgeId", "dbo.Rents");
            DropIndex("dbo.DVDs", new[] { "Rent_PledgeId" });
            DropColumn("dbo.DVDs", "RentId");
            RenameColumn(table: "dbo.DVDs", name: "Rent_PledgeId", newName: "RentId");
            DropPrimaryKey("dbo.Rents");
            AlterColumn("dbo.Rents", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.DVDs", "RentId", c => c.Int());
            AddPrimaryKey("dbo.Rents", "Id");
            CreateIndex("dbo.DVDs", "RentId");
            AddForeignKey("dbo.Rents", "PledgeId", "dbo.Pledges", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DVDs", "RentId", "dbo.Rents", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DVDs", "RentId", "dbo.Rents");
            DropForeignKey("dbo.Rents", "PledgeId", "dbo.Pledges");
            DropIndex("dbo.DVDs", new[] { "RentId" });
            DropPrimaryKey("dbo.Rents");
            AlterColumn("dbo.DVDs", "RentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Rents", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Rents", "PledgeId");
            RenameColumn(table: "dbo.DVDs", name: "RentId", newName: "Rent_PledgeId");
            AddColumn("dbo.DVDs", "RentId", c => c.Int(nullable: false));
            CreateIndex("dbo.DVDs", "Rent_PledgeId");
            AddForeignKey("dbo.DVDs", "Rent_PledgeId", "dbo.Rents", "PledgeId");
            AddForeignKey("dbo.Rents", "PledgeId", "dbo.Pledges", "Id");
        }
    }
}

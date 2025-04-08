namespace DVD_rent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrelationshipstoclasses : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Rents", new[] { "Pledge_Id" });
            RenameColumn(table: "dbo.Rents", name: "Pledge_Id", newName: "PledgeId");
            DropPrimaryKey("dbo.Rents");
            AddColumn("dbo.DVDs", "RentId", c => c.Int(nullable: false));
            AddColumn("dbo.DVDs", "Rent_PledgeId", c => c.Int());
            AddColumn("dbo.Rents", "ClientId", c => c.Int(nullable: false));
            AddColumn("dbo.Rents", "EmployeeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Rents", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Rents", "PledgeId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Rents", "PledgeId");
            CreateIndex("dbo.Rents", "PledgeId");
            CreateIndex("dbo.Rents", "ClientId");
            CreateIndex("dbo.Rents", "EmployeeId");
            CreateIndex("dbo.DVDs", "Rent_PledgeId");
            AddForeignKey("dbo.Rents", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DVDs", "Rent_PledgeId", "dbo.Rents", "PledgeId");
            AddForeignKey("dbo.Rents", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rents", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.DVDs", "Rent_PledgeId", "dbo.Rents");
            DropForeignKey("dbo.Rents", "ClientId", "dbo.Clients");
            DropIndex("dbo.DVDs", new[] { "Rent_PledgeId" });
            DropIndex("dbo.Rents", new[] { "EmployeeId" });
            DropIndex("dbo.Rents", new[] { "ClientId" });
            DropIndex("dbo.Rents", new[] { "PledgeId" });
            DropPrimaryKey("dbo.Rents");
            AlterColumn("dbo.Rents", "PledgeId", c => c.Int());
            AlterColumn("dbo.Rents", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Rents", "EmployeeId");
            DropColumn("dbo.Rents", "ClientId");
            DropColumn("dbo.DVDs", "Rent_PledgeId");
            DropColumn("dbo.DVDs", "RentId");
            AddPrimaryKey("dbo.Rents", "Id");
            RenameColumn(table: "dbo.Rents", name: "PledgeId", newName: "Pledge_Id");
            CreateIndex("dbo.Rents", "Pledge_Id");
        }
    }
}

namespace DVD_rent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneNumber = c.Int(nullable: false),
                        Address = c.String(maxLength: 100),
                        InBlackList = c.Boolean(nullable: false),
                        FullName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DVDs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Position = c.Int(nullable: false),
                        Login = c.String(maxLength: 100),
                        Password = c.String(maxLength: 100),
                        FullName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pledges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PledgeType = c.Int(nullable: false),
                        Series = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                        Money = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RentDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        State = c.Int(nullable: false),
                        Money = c.Single(nullable: false),
                        Pledge_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pledges", t => t.Pledge_Id)
                .Index(t => t.Pledge_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rents", "Pledge_Id", "dbo.Pledges");
            DropIndex("dbo.Rents", new[] { "Pledge_Id" });
            DropTable("dbo.Rents");
            DropTable("dbo.Pledges");
            DropTable("dbo.Movies");
            DropTable("dbo.Employees");
            DropTable("dbo.DVDs");
            DropTable("dbo.Clients");
        }
    }
}

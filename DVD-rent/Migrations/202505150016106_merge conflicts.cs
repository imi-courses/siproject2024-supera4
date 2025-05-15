namespace DVD_rent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mergeconflicts : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Login", c => c.String());
            AlterColumn("dbo.Employees", "Password", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Password", c => c.String(maxLength: 100));
            AlterColumn("dbo.Employees", "Login", c => c.String(maxLength: 100));
        }
    }
}

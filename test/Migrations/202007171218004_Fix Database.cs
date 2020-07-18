namespace test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDatabase : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Info", "TelNo", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.Info", "CellNo", c => c.String(maxLength: 20, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Info", "CellNo", c => c.String(nullable: false, maxLength: 20, unicode: false));
            AlterColumn("dbo.Info", "TelNo", c => c.String(nullable: false, maxLength: 20, unicode: false));
        }
    }
}

namespace MyReklama.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Services", "Price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Services", "Price", c => c.Double(nullable: false));
        }
    }
}

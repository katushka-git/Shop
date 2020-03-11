namespace MyReklama.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class с1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BodyOrders", "OrderId", c => c.Int(nullable: false));
            DropColumn("dbo.BodyOrders", "HeaderOrderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BodyOrders", "HeaderOrderId", c => c.Int(nullable: false));
            DropColumn("dbo.BodyOrders", "OrderId");
        }
    }
}

namespace MyReklama.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class с2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BodyOrders", "HeadOrder_Id", "dbo.HeadOrders");
            DropIndex("dbo.BodyOrders", new[] { "HeadOrder_Id" });
            RenameColumn(table: "dbo.BodyOrders", name: "HeadOrder_Id", newName: "HeadOrderId");
            AlterColumn("dbo.BodyOrders", "HeadOrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.BodyOrders", "HeadOrderId");
            AddForeignKey("dbo.BodyOrders", "HeadOrderId", "dbo.HeadOrders", "Id", cascadeDelete: true);
            DropColumn("dbo.BodyOrders", "OrderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BodyOrders", "OrderId", c => c.Int(nullable: false));
            DropForeignKey("dbo.BodyOrders", "HeadOrderId", "dbo.HeadOrders");
            DropIndex("dbo.BodyOrders", new[] { "HeadOrderId" });
            AlterColumn("dbo.BodyOrders", "HeadOrderId", c => c.Int());
            RenameColumn(table: "dbo.BodyOrders", name: "HeadOrderId", newName: "HeadOrder_Id");
            CreateIndex("dbo.BodyOrders", "HeadOrder_Id");
            AddForeignKey("dbo.BodyOrders", "HeadOrder_Id", "dbo.HeadOrders", "Id");
        }
    }
}

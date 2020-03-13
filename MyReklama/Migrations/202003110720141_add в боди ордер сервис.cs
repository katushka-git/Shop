namespace MyReklama.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addвбодиордерсервис : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.BodyOrders", "ServiceId");
            AddForeignKey("dbo.BodyOrders", "ServiceId", "dbo.Services", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BodyOrders", "ServiceId", "dbo.Services");
            DropIndex("dbo.BodyOrders", new[] { "ServiceId" });
        }
    }
}

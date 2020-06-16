namespace MyReklama.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BodyOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HeadOrderId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        Sum = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .ForeignKey("dbo.HeadOrders", t => t.HeadOrderId, cascadeDelete: true)
                .Index(t => t.HeadOrderId)
                .Index(t => t.ServiceId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOrder = c.DateTime(nullable: false),
                        ClientId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.EmployeeId)
                .Index(t => t.ServiceId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FIO = c.String(),
                        NameCompany = c.String(),
                        Adres = c.String(),
                        Tel = c.Int(nullable: false),
                        City = c.String(),
                        Index = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FIO = c.String(),
                        Adres = c.String(),
                        Tel = c.Int(nullable: false),
                        NumberOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HeadOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        Sum = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BodyOrders", "HeadOrderId", "dbo.HeadOrders");
            DropForeignKey("dbo.BodyOrders", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.Orders", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.Orders", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Orders", "ClientId", "dbo.Clients");
            DropIndex("dbo.Orders", new[] { "ServiceId" });
            DropIndex("dbo.Orders", new[] { "EmployeeId" });
            DropIndex("dbo.Orders", new[] { "ClientId" });
            DropIndex("dbo.BodyOrders", new[] { "ServiceId" });
            DropIndex("dbo.BodyOrders", new[] { "HeadOrderId" });
            DropTable("dbo.HeadOrders");
            DropTable("dbo.Employees");
            DropTable("dbo.Clients");
            DropTable("dbo.Orders");
            DropTable("dbo.Services");
            DropTable("dbo.BodyOrders");
        }
    }
}

namespace HotelManagment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Surname = c.String(nullable: false, maxLength: 50),
                        IsDelete = c.Boolean(),
                        Age = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 100),
                        token = c.String(),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDeleted = c.Boolean(),
                        RoomId = c.Int(nullable: false),
                        ResturantOrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.ResturantOrders", t => t.ResturantOrderId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.CustomerId)
                .Index(t => t.RoomId)
                .Index(t => t.ResturantOrderId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Surname = c.String(nullable: false, maxLength: 50),
                        Age = c.Int(nullable: false),
                        PassportNo = c.Int(nullable: false),
                        TotalPayment = c.Decimal(nullable: false, storeType: "money"),
                        IsDelete = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ResturantOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        FoodId = c.Int(nullable: false),
                        FoodCount = c.Int(nullable: false),
                        FoodOrderTotalPrice = c.Decimal(nullable: false, storeType: "money"),
                        RoomId = c.Int(nullable: false),
                        IsDelete = c.Boolean(),
                        ApplicationUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUserId, cascadeDelete: false)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: false)
                .ForeignKey("dbo.Foods", t => t.FoodId, cascadeDelete: false)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: false)
                .Index(t => t.CustomerId)
                .Index(t => t.FoodId)
                .Index(t => t.RoomId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FoodName = c.String(nullable: false, maxLength: 50),
                        FoodPrice = c.Decimal(nullable: false, storeType: "money"),
                        IsDelete = c.Boolean(),
                        FoodCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FoodCategories", t => t.FoodCategoryId, cascadeDelete: true)
                .Index(t => t.FoodCategoryId);
            
            CreateTable(
                "dbo.FoodCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        RoomNo = c.Int(nullable: false),
                        DailyPrice = c.Decimal(nullable: false, storeType: "money"),
                        PersonCapacity = c.Int(nullable: false),
                        ChildCapacity = c.Int(nullable: false),
                        BedTypeId = c.Int(nullable: false),
                        Photo = c.String(),
                        Desc = c.String(nullable: false, maxLength: 50),
                        IsDelete = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BedTypes", t => t.BedTypeId, cascadeDelete: true)
                .Index(t => t.BedTypeId);
            
            CreateTable(
                "dbo.BedTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUsers", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.ResturantOrders", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Bookings", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "BedTypeId", "dbo.BedTypes");
            DropForeignKey("dbo.ResturantOrders", "FoodId", "dbo.Foods");
            DropForeignKey("dbo.Foods", "FoodCategoryId", "dbo.FoodCategories");
            DropForeignKey("dbo.ResturantOrders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Bookings", "ResturantOrderId", "dbo.ResturantOrders");
            DropForeignKey("dbo.ResturantOrders", "ApplicationUserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Bookings", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Bookings", "ApplicationUserId", "dbo.ApplicationUsers");
            DropIndex("dbo.Rooms", new[] { "BedTypeId" });
            DropIndex("dbo.Foods", new[] { "FoodCategoryId" });
            DropIndex("dbo.ResturantOrders", new[] { "ApplicationUserId" });
            DropIndex("dbo.ResturantOrders", new[] { "RoomId" });
            DropIndex("dbo.ResturantOrders", new[] { "FoodId" });
            DropIndex("dbo.ResturantOrders", new[] { "CustomerId" });
            DropIndex("dbo.Bookings", new[] { "ResturantOrderId" });
            DropIndex("dbo.Bookings", new[] { "RoomId" });
            DropIndex("dbo.Bookings", new[] { "CustomerId" });
            DropIndex("dbo.Bookings", new[] { "ApplicationUserId" });
            DropIndex("dbo.ApplicationUsers", new[] { "RoleId" });
            DropTable("dbo.Roles");
            DropTable("dbo.BedTypes");
            DropTable("dbo.Rooms");
            DropTable("dbo.FoodCategories");
            DropTable("dbo.Foods");
            DropTable("dbo.ResturantOrders");
            DropTable("dbo.Customers");
            DropTable("dbo.Bookings");
            DropTable("dbo.ApplicationUsers");
        }
    }
}

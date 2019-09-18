namespace HotelManagment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResturantOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "ResturantOrderId", "dbo.ResturantOrders");
            DropIndex("dbo.Bookings", new[] { "ResturantOrderId" });
            AddColumn("dbo.ResturantOrders", "BookingId", c => c.Int(nullable: false));
            CreateIndex("dbo.ResturantOrders", "BookingId");
            AddForeignKey("dbo.ResturantOrders", "BookingId", "dbo.Bookings", "Id", cascadeDelete: true);
            DropColumn("dbo.Bookings", "ResturantOrderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "ResturantOrderId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ResturantOrders", "BookingId", "dbo.Bookings");
            DropIndex("dbo.ResturantOrders", new[] { "BookingId" });
            DropColumn("dbo.ResturantOrders", "BookingId");
            CreateIndex("dbo.Bookings", "ResturantOrderId");
            AddForeignKey("dbo.Bookings", "ResturantOrderId", "dbo.ResturantOrders", "Id", cascadeDelete: true);
        }
    }
}

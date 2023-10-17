namespace MvcOnlineCommercialAutomation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shipment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShipmentDetails",
                c => new
                    {
                        ShipmentDetailID = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 300, unicode: false),
                        TrackingNumber = c.String(maxLength: 10, unicode: false),
                        Employee = c.String(maxLength: 20, unicode: false),
                        Receiver = c.String(maxLength: 25, unicode: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ShipmentDetailID);
            
            CreateTable(
                "dbo.ShipmentTracks",
                c => new
                    {
                        ShipmentTrackID = c.Int(nullable: false, identity: true),
                        TrackingNumber = c.String(maxLength: 10, unicode: false),
                        Description = c.String(maxLength: 100, unicode: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ShipmentTrackID);
            
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CargoTracks",
                c => new
                    {
                        CargoTrackID = c.Int(nullable: false, identity: true),
                        TrackingNumber = c.String(maxLength: 10, unicode: false),
                        Description = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.CargoTrackID);
            
            CreateTable(
                "dbo.CargoDetails",
                c => new
                    {
                        CargoDetailID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.CargoDetailID);
            
            DropTable("dbo.ShipmentTracks");
            DropTable("dbo.ShipmentDetails");
        }
    }
}

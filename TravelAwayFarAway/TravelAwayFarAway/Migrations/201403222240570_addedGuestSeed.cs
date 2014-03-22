namespace TravelAwayFarAway.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedGuestSeed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        TripId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        startDate = c.DateTime(nullable: false),
                        endDate = c.DateTime(nullable: false),
                        minimunNumberOfGuests = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TripId);
            
            CreateTable(
                "dbo.Legs",
                c => new
                    {
                        LegId = c.Int(nullable: false, identity: true),
                        tripId = c.Int(nullable: false),
                        legName = c.String(),
                        startLocation = c.String(),
                        endLocation = c.String(),
                        LegtartDate = c.DateTime(nullable: false),
                        legEndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LegId)
                .ForeignKey("dbo.Trips", t => t.tripId, cascadeDelete: true)
                .Index(t => t.tripId);
            
            CreateTable(
                "dbo.Guests",
                c => new
                    {
                        GuestId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GuestId);
            
            CreateTable(
                "dbo.GuestLegs",
                c => new
                    {
                        Guest_GuestId = c.Int(nullable: false),
                        Leg_LegId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Guest_GuestId, t.Leg_LegId })
                .ForeignKey("dbo.Guests", t => t.Guest_GuestId, cascadeDelete: true)
                .ForeignKey("dbo.Legs", t => t.Leg_LegId, cascadeDelete: true)
                .Index(t => t.Guest_GuestId)
                .Index(t => t.Leg_LegId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.GuestLegs", new[] { "Leg_LegId" });
            DropIndex("dbo.GuestLegs", new[] { "Guest_GuestId" });
            DropIndex("dbo.Legs", new[] { "tripId" });
            DropForeignKey("dbo.GuestLegs", "Leg_LegId", "dbo.Legs");
            DropForeignKey("dbo.GuestLegs", "Guest_GuestId", "dbo.Guests");
            DropForeignKey("dbo.Legs", "tripId", "dbo.Trips");
            DropTable("dbo.GuestLegs");
            DropTable("dbo.Guests");
            DropTable("dbo.Legs");
            DropTable("dbo.Trips");
        }
    }
}

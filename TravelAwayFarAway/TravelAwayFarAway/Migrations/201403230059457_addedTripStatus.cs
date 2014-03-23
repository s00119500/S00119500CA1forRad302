namespace TravelAwayFarAway.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedTripStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trips", "tripStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trips", "tripStatus");
        }
    }
}

namespace TravelAwayFarAway.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class spellingCheck : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trips", "currentNumberOfGuests", c => c.Int(nullable: false));
            AddColumn("dbo.Legs", "LegStartDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Legs", "LegtartDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Legs", "LegtartDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Legs", "LegStartDate");
            DropColumn("dbo.Trips", "currentNumberOfGuests");
        }
    }
}

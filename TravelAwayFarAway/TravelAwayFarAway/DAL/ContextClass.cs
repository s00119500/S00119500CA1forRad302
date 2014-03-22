using MvcApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TravelAwayFarAway.DAL
{
    public class ContextClass : DbContext
    {
        public DbSet<Trip> trip { get; set; }
        public DbSet<Leg> leg { get; set; }
        public DbSet<Guest> guest { get; set; }  
    }
}
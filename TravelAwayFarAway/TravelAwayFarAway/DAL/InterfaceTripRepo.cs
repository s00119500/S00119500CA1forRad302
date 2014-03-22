using MvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAwayFarAway.DAL
{
    public interface InterfaceTripRepo
    {
        IQueryable<Trip> displayTrips();
        IQueryable<Leg> displayLegs();
        IQueryable<Guest> displayGuests();
    }
}

using MvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelAwayFarAway.DAL
{
    public class TripRepo:InterfaceTripRepo
    {
        private ContextClass context;
        public TripRepo() 
        {
            context = new ContextClass();
        }
        public IQueryable<Trip> displayTrips() 
        {
            return context.trip;
        }

        public IQueryable<Leg> displayLegs()
        {
            return context.leg;
        }

        public IQueryable<Guest> displayGuests()
        {
            return context.guest;
        }

    }
}
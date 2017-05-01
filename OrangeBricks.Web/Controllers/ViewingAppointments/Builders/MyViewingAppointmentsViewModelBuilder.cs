using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using OrangeBricks.Web.Controllers.Offers.ViewModels;
using OrangeBricks.Web.Models;
using System;

namespace OrangeBricks.Web.Controllers.Offers.Builders
{
    public class MyViewingAppointmentsViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public MyViewingAppointmentsViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public MyViewingAppointmentsViewModel Build(string buyerId)
        {
            var propertyAppointments = _context.Properties
                .Where(p => p.Offers.Any())
                .Select(p => new
                {
                    ViewingAppointments = p.ViewingAppointments.Where(a => a.BuyerUserId == buyerId && a.AppointmentTime > DateTime.Now),
                    Property = p
                })
                .SelectMany(p => p.ViewingAppointments.Select(a => new MyViewingAppointment
                {
                    PropertyType = p.Property.PropertyType,
                    NumberOfBedrooms = p.Property.NumberOfBedrooms,
                    StreetName = p.Property.StreetName,
                    PropertyId = p.Property.Id,
                    ViewingAppointmentId = a.Id,
                    AppointmentTime = a.AppointmentTime,
                    CreatedAt = a.CreatedAt
                }))
                .ToList();

            var myViewingAppointmentsViewModel = new MyViewingAppointmentsViewModel { Appointments = propertyAppointments.OrderBy(a => a.AppointmentTime).ToList() };

            return myViewingAppointmentsViewModel;
        }
    }
}
using System;
using System.Collections.Generic;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Property.Commands
{
    public class MakeViewingAppointmentCommandHandler
    {
        private readonly IOrangeBricksContext _context;

        public MakeViewingAppointmentCommandHandler(IOrangeBricksContext context)
        {
            _context = context;
        }

        public void Handle(MakeViewingAppointmentCommand command)
        {
            var property = _context.Properties.Find(command.PropertyId);

            var viewingAppointment = new ViewingAppointment
            {
                AppointmentTime = command.AppointmentTime,
                BuyerUserId = command.BuyerUserId,
                IsAvailable = false,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            if (property.ViewingAppointments == null)
            {
                property.ViewingAppointments = new List<ViewingAppointment>();
            }

            property.ViewingAppointments.Add(viewingAppointment);

            _context.SaveChanges();
        }
    }
}
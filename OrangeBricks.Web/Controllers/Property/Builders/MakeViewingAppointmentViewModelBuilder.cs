using OrangeBricks.Web.Controllers.Property.ViewModels;
using OrangeBricks.Web.Models;
using System;
using System.Linq;
using System.Data.Entity;

namespace OrangeBricks.Web.Controllers.Property.Builders
{
    public class MakeViewingAppointmentViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public MakeViewingAppointmentViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public MakeViewingAppointmentViewModel Build(int id)
        {
            var property = _context.Properties
                .Where(p => p.Id == id)
                .Include(x => x.ViewingAppointments)
                .SingleOrDefault();

            var scheduleDateTime = DateTime.Today.AddDays(1).AddHours(8);
            var maxScheduleDateTime = DateTime.Today.AddDays(8).AddHours(16);

            var availableAppointmentTimes = Enumerable.Range(0, 1 + (int)maxScheduleDateTime.Subtract(scheduleDateTime).TotalHours)
                .Select(offset => scheduleDateTime.AddHours(offset))
                .Where(t => t.Hour >= 8 && t.Hour <= 16)
                .ToList()
                .Except(property.ViewingAppointments.Select(a => a.AppointmentTime).ToList());

            return new MakeViewingAppointmentViewModel
            {
                PropertyId = property.Id,
                PropertyType = property.PropertyType,
                StreetName = property.StreetName,
                NumberOfBedrooms = property.NumberOfBedrooms,
                AvailableAppointmentTimes = availableAppointmentTimes.ToList()
            };
        }
    }
}
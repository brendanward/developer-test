using System.Collections.Generic;
using System;

namespace OrangeBricks.Web.Controllers.Property.ViewModels
{
    public class MakeViewingAppointmentViewModel
    {
        public string PropertyType { get; set; }
        public int NumberOfBedrooms { get; set; }
        public string StreetName { get; set; }
        public int PropertyId { get; set; }
        public List<DateTime> AvailableAppointmentTimes { get; set; }
    }
}
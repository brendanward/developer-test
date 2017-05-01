using System.Collections.Generic;
using System;

namespace OrangeBricks.Web.Controllers.Offers.ViewModels
{
    public class MyViewingAppointmentsViewModel
    {
        public List<MyViewingAppointment> Appointments { get; set; }
    }

    public class MyViewingAppointment
    {
        public string PropertyType { get; set; }
        public int NumberOfBedrooms { get; set; }
        public string StreetName { get; set; }
        public int PropertyId { get; set; }
        public int ViewingAppointmentId;
        public DateTime AppointmentTime { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
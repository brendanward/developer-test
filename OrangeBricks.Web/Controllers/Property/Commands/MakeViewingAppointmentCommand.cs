using System;

namespace OrangeBricks.Web.Controllers.Property.Commands
{
    public class MakeViewingAppointmentCommand
    {
        public int PropertyId { get; set; }

        public DateTime AppointmentTime { get; set; }

        public string BuyerUserId { get; set; }
    }
}
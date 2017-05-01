using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OrangeBricks.Web.Models
{
    public class ViewingAppointment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime AppointmentTime { get; set; }

        [Required]
        public string BuyerUserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
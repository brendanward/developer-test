using System;
using System.Data.Entity;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using OrangeBricks.Web.Controllers.Property.Commands;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Tests.Controllers.Property.Commands
{
    [TestFixture]
    public class MakeViewingAppointmentCommandHandlerTest
    {
        private MakeViewingAppointmentCommandHandler _handler;
        private IOrangeBricksContext _context;
        private IDbSet<Models.Property> _properties;

        [SetUp]
        public void SetUp()
        {
            _context = Substitute.For<IOrangeBricksContext>();
            _properties = Substitute.For<IDbSet<Models.Property>>();
            _handler = new MakeViewingAppointmentCommandHandler(_context);
            _context.Properties.Returns(_properties);
        }

        [Test]
        public void HandleShouldAddViewingAppointment()
        {
            var property = new Models.Property
            {
                Description = "Test Property",
                IsListedForSale = false
            };

            _properties.Find(1).Returns(property);

            var appointmentTime = new DateTime(2017, 4, 30, 12, 0, 0);

            var command = new MakeViewingAppointmentCommand();
            command.PropertyId = 1;
            command.AppointmentTime = appointmentTime;
            command.BuyerUserId = "Test Buyer";

            _handler.Handle(command);

            _context.Properties.Received(1).Find(1);
            _context.Received(1).SaveChanges();
            Assert.True(property.ViewingAppointments.Count == 1);
            Assert.True(property.ViewingAppointments.First().AppointmentTime == appointmentTime);
            Assert.True(property.ViewingAppointments.First().BuyerUserId == "Test Buyer");
        }
    }
}


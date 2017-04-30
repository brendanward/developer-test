using System.Data.Entity;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using OrangeBricks.Web.Controllers.Property.Commands;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Tests.Controllers.Property.Commands
{
    [TestFixture]
    public class MakeOfferCommandHandlerTest
    {
        private MakeOfferCommandHandler _handler;
        private IOrangeBricksContext _context;
        private IDbSet<Models.Property> _properties;

        [SetUp]
        public void SetUp()
        {
            _context = Substitute.For<IOrangeBricksContext>();
            _properties = Substitute.For<IDbSet<Models.Property>>();
            _handler = new MakeOfferCommandHandler(_context);
            _context.Properties.Returns(_properties);
        }

        [Test]
        public void HandleShouldAddOffer()
        {
            var property = new Models.Property
            {
                Description = "Test Property",
                IsListedForSale = false
            };

            _properties.Find(1).Returns(property);

            var command = new MakeOfferCommand();
            command.PropertyId = 1;
            command.Offer = 9999;
            command.BuyerUserId = "Test Buyer";

            _handler.Handle(command);

            _context.Properties.Received(1).Find(1);
            _context.Received(1).SaveChanges();
            Assert.True(property.Offers.Count == 1);
            Assert.True(property.Offers.First().Amount == 9999);
            Assert.True(property.Offers.First().BuyerUserId == "Test Buyer");
        }
    }
}

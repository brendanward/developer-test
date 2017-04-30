using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using OrangeBricks.Web.Controllers.Offers.ViewModels;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Offers.Builders
{
    public class MyOffersViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public MyOffersViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public MyOffersViewModel Build(string buyerId)
        {
            var propertyOffers = _context.Properties
                .Where(p => p.Offers.Any())
                .Select(p => new
                {
                    Offers = p.Offers.Where(o => o.BuyerUserId == buyerId),
                    Property = p
                })
                .SelectMany(p => p.Offers.Select(o => new MyOfferOnProperty
                {
                    PropertyType = p.Property.PropertyType,
                    NumberOfBedrooms = p.Property.NumberOfBedrooms,
                    StreetName = p.Property.StreetName,
                    PropertyId = p.Property.Id,
                    OfferId = o.Id,
                    Amount = o.Amount,
                    CreatedAt = o.CreatedAt,
                    Status = o.Status.ToString()
                }))
                .ToList();

            var myOfferViewModel = new MyOffersViewModel { Offers = propertyOffers };

            return myOfferViewModel;
        }
    }
}
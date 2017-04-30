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
            var offers = _context.Offers
                .Where(o => o.BuyerUserId == buyerId)
                .Select(o => new OfferViewModel
                {
                    Id = o.Id,
                    Amount = o.Amount,
                    CreatedAt = o.CreatedAt,
                    Status = o.Status.ToString()
                })
                .ToList();

            var myOfferViewModel = new MyOffersViewModel { Offers = offers };

            return myOfferViewModel;
        }
    }
}
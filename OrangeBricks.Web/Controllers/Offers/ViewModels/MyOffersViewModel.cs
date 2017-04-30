using System.Collections.Generic;
using System;

namespace OrangeBricks.Web.Controllers.Offers.ViewModels
{
    public class MyOffersViewModel
    {
        public List<MyOfferOnProperty> Offers { get; set; }
    }

    public class MyOfferOnProperty
    {
        public string PropertyType { get; set; }
        public int NumberOfBedrooms { get; set; }
        public string StreetName { get; set; }
        public int PropertyId { get; set; }
        public int OfferId;
        public int Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }
    }
}
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OrangeBricks.Web.Attributes;
using OrangeBricks.Web.Controllers.Offers.Builders;
using OrangeBricks.Web.Controllers.Offers.Commands;
using OrangeBricks.Web.Models;

namespace OrangeBricks.Web.Controllers.Offers
{
    public class ViewingAppointmentsController : Controller
    {
        private readonly IOrangeBricksContext _context;

        public ViewingAppointmentsController(IOrangeBricksContext context)
        {
            _context = context;
        }

        [OrangeBricksAuthorize(Roles = "Buyer")]
        public ActionResult MyViewingAppointments()
        {
            var builder = new MyViewingAppointmentsViewModelBuilder(_context);
            var viewModel = builder.Build(User.Identity.GetUserId());

            return View(viewModel);
        }
    }
}
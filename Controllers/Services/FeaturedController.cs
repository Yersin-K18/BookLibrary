using System.Web.Mvc;

namespace BookLibrary.Controllers.Services
{
    public class FeaturedController : Controller
    {
        // GET: Featured
        public ActionResult GetFeatured()
        {
            return PartialView("_Featured");
        }
    }
}
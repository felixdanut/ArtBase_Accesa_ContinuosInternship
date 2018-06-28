using System.Web.Mvc;

namespace ArtBase.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Login()
        {
            ViewBag.Title = "ArtBase Login";

            return View();
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Portal ArtBase";

            return View();
        }
    }
}

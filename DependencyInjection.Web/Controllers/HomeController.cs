using System.Web.Mvc;

namespace DependencyInjection.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult AddContact()
        {
            return View();
        }

        public ActionResult EditContact()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace EventPlanner.Controllers
{
    public class HomeController : Controller
    {
      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }
    }
}

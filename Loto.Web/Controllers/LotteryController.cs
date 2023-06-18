using Microsoft.AspNetCore.Mvc;

namespace Loto.Web.Controllers
{
    public class LotteryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Modes()
        {
            return View();
        }
    }
}

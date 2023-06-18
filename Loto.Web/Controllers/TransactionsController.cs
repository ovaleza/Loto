using Microsoft.AspNetCore.Mvc;

namespace Loto.Web.Controllers
{
    public class TransactionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Recharges()
        {
            return View();
        }
        public IActionResult Invoices()
        {
            return View();
        }
    }
}

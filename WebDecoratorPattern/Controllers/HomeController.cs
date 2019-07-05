using Microsoft.AspNetCore.Mvc;
using WebDecoratorPattern.Infrastructure.Extensions;

namespace WebDecoratorPattern.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View().WithSuccess("SuccessMessage","call me From With Success");
        }
    }
}
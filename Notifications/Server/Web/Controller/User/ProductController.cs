using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class ProductController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

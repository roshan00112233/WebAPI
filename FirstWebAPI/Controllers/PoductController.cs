using Microsoft.AspNetCore.Mvc;

namespace FIrstWebAPI.Controllers
{
    public class PoductController : Controller
    {
        public IActionResult GetAllProducts()
        {
            var products = new List<String>
            {
                "laptop",
                "smartphone",
                "smartphone",
            };

            return Ok(products);
        }
    }
}

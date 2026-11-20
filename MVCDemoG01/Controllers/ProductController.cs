using Microsoft.AspNetCore.Mvc;
using MVC_01.Models;

namespace MVC_01.Controllers
{
    [Route("Prod")]
    public class ProductController : Controller
    {
        #region Routing

        [HttpGet("JsonAction")]
        public IActionResult JsonAction()
        {
            return Json("Hello From Json Action");
        }

        #endregion

        #region Model Binding

        [HttpGet("Search")]
        public IActionResult Search(ProductFilters filter)
        {
            return View(filter);
        }

        #endregion
    }
}
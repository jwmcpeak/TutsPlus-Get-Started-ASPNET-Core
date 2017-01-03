using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace secondapp.Controllers
{
    public class ProductsController : Controller
    {
        public string Index()
        {
            return "Products Index";
        }

        public string Edit(int id)
        {
            return $"Product ID: {id}";
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

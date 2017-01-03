using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace secondapp.Controllers
{
    public class GuitarsController : Controller
    {
        public string Index()
        {
            return "Guitars Index";
        }

        public string Edit(int id)
        {
            return $"Guitar ID: {id}";
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using secondapp.Data;

namespace secondapp.Controllers
{
    public class GuitarsController : Controller
    {
        private readonly IGuitarRepository _repo;

        public GuitarsController(IGuitarRepository repository) {
            _repo = repository;
        }

        public IActionResult Index()
        {
            var guitars = _repo.All();

            return View(guitars);
        }

        //[Route("products/guitars/{id}")]
        public IActionResult SingleProduct(int id) {
            var guitar = _repo.Get(id);

            if (guitar == null) {
                return NotFound();
            }

            return View(guitar);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var guitar = _repo.Get(id);

            if (guitar == null) {
                return NotFound();
            }

            return View(guitar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection form) {
            var guitar = _repo.Get(id);

            if (guitar == null) {
                return NotFound();
            }

            await TryUpdateModelAsync(guitar);

            _repo.Update(guitar);

            //return RedirectToAction("index", new { controller = "guitars"});
            return RedirectToRoute("guitars-index");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

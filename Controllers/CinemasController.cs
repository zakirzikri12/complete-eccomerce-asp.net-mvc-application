using eTikects.Data;
using eTikects.Models;
using eTikects.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTikects.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemasService _service;

        public CinemasController(ICinemasService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allCinemas = await _service.GetAllAsync();
            return View(allCinemas);
        }

        // GET: Cinemas/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _service.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }

        //GET: Cinemas/Detail/1

        public async Task<IActionResult> Details(int id)
        {
            var CinemaDetails = await _service.GetByIdAsync(id);
            if (CinemaDetails == null) { return View("NotFound"); }
            return View(CinemaDetails);
        }

        //GET : Cinemas/Edit/1

        public async Task<ActionResult> Edit(int id) 
        {
            var CinemaDetails = await _service.GetByIdAsync(id);
            if (CinemaDetails == null) { return View("NotFound"); }
            return View(CinemaDetails);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid) { return View(cinema); }

            await _service.UpdateAsync(id, cinema);
            return RedirectToAction(nameof(Index));
        }

        //GET : Cinemas/Delete/1

        public async Task<IActionResult> Delete(int id)
        {
            var CinemaDetails = await _service.GetByIdAsync(id);
            if (CinemaDetails == null) { return View("NotFound"); }
            return View(CinemaDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id, [Bind("Id")] Cinema cinema)
        {
            var CinemaDetails = await _service.GetByIdAsync(id);
            if (CinemaDetails == null) { return View("NotFound"); }

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

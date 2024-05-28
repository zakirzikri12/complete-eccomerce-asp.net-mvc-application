using eTikects.Data;
using eTikects.Models;
using eTikects.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace eTikects.Controllers
{
    public class ActorsController : Controller
    {

        //inject services
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
         
            _service = service;
        }

      
        public async Task<IActionResult> Index()
        {
        
            var data = await _service.GetAllAsync();

            return View(data);
        }


        // GET: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Fullname,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        //GET : Actors/Detail/1
       
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);

            if (actorDetails == null) return View("NotFound");

            return View(actorDetails); 
        }

        //GET Actor/Edit/1

        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit( int id,[Bind("Id,Fullname,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.UpdateAsync(id,actor);
            return RedirectToAction(nameof(Index));
        }


        //GET Actor/Delete/1

        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id, [Bind("Id")] Actor actor)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
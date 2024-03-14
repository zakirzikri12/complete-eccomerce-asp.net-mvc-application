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
            var data = await _service.GetAll();

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
            _service.Add(actor);
            return RedirectToAction(nameof(Index));
        }

        //GET : Actors/Detail/1
    }
}
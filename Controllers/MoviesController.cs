using eTickets.Data.Services;
using eTikects.Data;
using eTikects.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eTikects.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }

        //INDEX
        public async Task<IActionResult> Index()
        {
            var allMovies = await _service.GetAllAsync(n => n.Cinema);
            return View(allMovies);
        }

        //FILTER
        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _service.GetAllAsync(n => n.Cinema);

            if (!string.IsNullOrEmpty(searchString))
            {
                //var filteredResult = allMovies.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                var filteredResultNew = allMovies.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allMovies);
        }

        //GET: Movies/Details/1

        public async Task<IActionResult> Details(int id)
        {
            var MovieDetail = await _service.GetByIdAsync(id);
            return View(MovieDetail);
        }

        //GET: Movies/Create
        //WITH VIEWMODEL
        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
                var moviewDropdownsData = await _service.GetNewMovieDropdownsValues();

                ViewBag.Cinemas = new SelectList(moviewDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(moviewDropdownsData.Producers, "Id", "Fullname");
                ViewBag.Actors = new SelectList(moviewDropdownsData.Actors, "Id", "Fullname");


                return View(movie);
            }
            await _service.AddNewMovieAsync(movie);
            return RedirectToAction("Index");
        }


        //GET: Movies/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);
            if (movieDetails == null) return View("NotFound");

            var response = new NewMovieVM()
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = (double)movieDetails.Price,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                ImageUrl = movieDetails.ImageUrl,
                MovieCategory = movieDetails.MovieCategory,
                CinemaId = movieDetails.CinemaId,
                ProducerId = movieDetails.ProducerId,
                ActorIds = movieDetails.Actor_Movies.Select(n => n.ActorId).ToList(),
            };

            var movieDropdownsData = await _service.GetNewMovieDropdownsValues();
            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "Fullname");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "Fullname");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {
            if (id != movie.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "Fullname");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "Fullname");

                return View(movie);
            }

            await _service.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }


    }
}

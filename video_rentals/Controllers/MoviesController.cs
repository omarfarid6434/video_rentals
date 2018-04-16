using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using video_rentals.Models;
using video_rentals.ViewModels;

namespace video_rentals.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        } 

        public ViewResult Index()
        {
            var movies = _context.Movie.Include(m => m.Genre).ToList();

            return View(movies);
        }

        public ViewResult New()
        {
            var genres = _context.Genre.ToList();

            var viewmodel = new MovieFormViewModel
            {
                Genre = genres
            };

            return View("MovieForm", viewmodel);
            
        
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movie.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                Movie = movie,
                Genre = _context.Genre.ToList()
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movie.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewmodel = new MovieFormViewModel(movie)
                {
                    Genre = _context.Genre.ToList()
                };
                return View("MovieForm", viewmodel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movie.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movie.SingleOrDefault(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.RealaseDate = movie.RealaseDate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

    }
}
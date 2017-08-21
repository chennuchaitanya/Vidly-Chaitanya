using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Random()
        {
            var movie = new RandomMovieViewModel { Movie = _context.Movie.Include(c => c.Genre).ToList() };
            return View(movie);            
        }

        public ActionResult Edit(int id)
        {
            ViewResult v = new ViewResult();
            
            return Content("Id=" +id);
        }

        [Route("movies/released/{year}/{month:range(1,12)}")]
        public ActionResult ByReleaseDate(int year,int month)
        {
            return Content(year + "/"+ month);
        }
        
        public ActionResult New()
        {
            try
            {
                var viewModel = new MovieFormViewModel { Genres = _context.Genre.ToList() };
                return View("New", viewModel);
            }
            catch(Exception ex)
            {
                return View();
            }
            
            //return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;
using System.Data.Entity;
using System.Web.Mvc.Html;

namespace WebApplication1.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context=new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();

        }


        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = _context.Genres;
            var viewModel = new MovieFormViewModel() {Genres = genres};
            return View("MovieForm", viewModel);
        }


        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Single(m => m.Id == id);

            if (movie == null)
             return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie) {Genres = _context.Genres};
             return View("MovieForm", viewModel);
        }



        [Route("movies/released/{year:regex(\\d{4}):range(1990,2018)}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }



        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
             {
                var viewModel=new MovieFormViewModel(movie);
                {
                    viewModel.Genres = _context.Genres;
                }           
                return View("MovieForm", viewModel);
             }

            if (movie.Id == 0)
              {

                  movie.DateAdded = DateTime.Today.Date;
                 _context.Movies.Add(movie);

              }
           else
             {
                 var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                 movieInDb.Name = movie.Name;
                 movieInDb.GenreId = movie.GenreId;
                 movieInDb.ReleaseDate = movie.ReleaseDate;
                 movieInDb.NumberOfItemsInStock = movie.NumberOfItemsInStock;
                
             }
              _context.SaveChanges();

             return RedirectToAction("Index","Movies");
        }


        public ActionResult Index()
        {

            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");
            
            else
                return View("ReadOnlyList");

        }

        //public ActionResult Details(int? id)
        //{
        //    var movie = _context.Movies.Include(c=>c.Genre).SingleOrDefault(m => m.Id == id);
            
        //    if (movie == null)
        //    {
        //        return HttpNotFound();

        //    }
        //    else
        //    {
        //        return View(movie);
        //    }
        //}
    }

}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.UI.WebControls;
using WebApplication1.Dtos;
using WebApplication1.Models;
using AutoMapper;

namespace WebApplication1.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context=new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: api/Movies
        public IHttpActionResult GetMovies(string query=null)
        {
            var moviesQuery = _context.Movies.Include(m=>m.Genre).Where(m=>m.NumberAvailable>0);

            if (!string.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

            var movieDtos = moviesQuery.ToList().Select(Mapper.Map<Movie, MovieDto>);
                //moviesQuery.Select(Mapper.Map<Movie, MovieDto>);

            return Ok(movieDtos);

        }

        // GET: api/Movies/5
       // [ResponseType(typeof(Movie))]
        public IHttpActionResult GetMovie(int id)
        {
            Movie movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok( Mapper.Map<Movie, MovieDto>(movie));
        }


        // PUT: api/Movies/5
        //[ResponseType(typeof(void))]
        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPut]
        public IHttpActionResult PutMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movieDto.Id)
            {
                return BadRequest("Movie not found in the database");
            }

            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            Mapper.Map(movieDto, movie);

            _context.SaveChanges();

            return Ok ("update successful");

        }


        // POST: api/Movies
        //[ResponseType(typeof(Movie))]
        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPost]
        public IHttpActionResult PostMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movie);
        }

        // DELETE: api/Movies/5
        //[ResponseType(typeof(Movie))]
        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var movieDb = _context.Movies.FirstOrDefault(m => m.Id == id);

            if (movieDb == null)
                return NotFound();

            _context.Movies.Remove(movieDb);
            _context.SaveChanges();

            return Ok("Deleted successfully");
        }

      

        private bool MovieExists(int id)
        {
            return _context.Movies.Count(e => e.Id == id) > 0;
        }
    }
}
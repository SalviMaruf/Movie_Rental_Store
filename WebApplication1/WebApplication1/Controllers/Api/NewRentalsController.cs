﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.UI.WebControls;
using WebApplication1.Models;

namespace WebApplication1.Controllers.Api
{
    public class NewRentalsController:ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context=new ApplicationDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {        
            var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);
          
            var movies = _context.Movies.Where(
                m => newRental.MovieIds.Contains(m.Id)).ToList();


            foreach (var movie in movies)
            {
                if (movie.NumberAvailable==0)
                {
                    return BadRequest("movie is not available.");
                }
                movie.NumberOfItemsInStock--;
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();
            return Ok();
        }
    }
}
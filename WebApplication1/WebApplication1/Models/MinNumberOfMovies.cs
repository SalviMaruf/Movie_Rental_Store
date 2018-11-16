using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class MinNumberOfMovies:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie) validationContext.ObjectInstance;
            if(movie.NumberOfItemsInStock>=1 && movie.NumberOfItemsInStock<=20)
                return ValidationResult.Success;
            else
            {
                return new ValidationResult("The field NumberInStock must be between 1 and 20");
            }
        }
    }
}
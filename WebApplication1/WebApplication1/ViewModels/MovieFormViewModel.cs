using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name;

        [Display(Name = "Genre")]
        [Required]
        public short? GenreId { get; set; }

        [Display(Name = "Release Date")]


        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        [Required]
        public short NumberOfItemsInStock { get; set; }


        public string Title => (Id != 0) ? "Edit Movie" : "New Movie";

        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberOfItemsInStock = movie.NumberOfItemsInStock;
            GenreId = movie.GenreId;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(255, ErrorMessage = "The maximum length for the name is 255 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Genre field is required.")]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        [Required(ErrorMessage = "The Release Date is required.")]
        [DataType(DataType.DateTime, ErrorMessage = "The data type must be Datetime format.")]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Required(ErrorMessage = "The Number in Stock field is required.")]
        [Range(1, 20, ErrorMessage = "The Number of movies must be between 1 and 20.")]
        [Display(Name = "Number in Stock")]
        public int NumberInStock { get; set; }

        public override string ToString()
        {
            return "{ id:int, name:string, genreId:int, releaseDate:Datetime,  numberInStock:int }";
        }
    }
}
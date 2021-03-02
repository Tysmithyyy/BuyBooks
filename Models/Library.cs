using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BuyBooks.Models
{
    //creates Library class which will hold information about each book on the website.
    public class Library
    {
        [Key]
        [Required]
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string AuthorFirstName { get; set; }

        [Required]
        public string AuthorLastName { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Required]
        [RegularExpression(@"\d{3}-\d{10}",
         ErrorMessage = "Please enter a valid ISBN")]
        public string ISBN { get; set; }

        [Required]
        public string Class { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public int PageCount { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}

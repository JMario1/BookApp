using System;
using System.ComponentModel.DataAnnotations;

namespace BookApp.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string? Title {get; set;}

        public string? ISBN {get; set;}

        public DateTime PublishedDate {get; set;}
        
        public int AuthorId {get; set;}

        [Required]
        public Author? Author {get; set;}
    }
}
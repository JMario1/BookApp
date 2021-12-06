
using System.ComponentModel.DataAnnotations;

namespace BookApp.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        public string Name {get; set;}
        public int Age {get; set;}

        // public List<Book> PublishedBooks {get; set;}

    }
}
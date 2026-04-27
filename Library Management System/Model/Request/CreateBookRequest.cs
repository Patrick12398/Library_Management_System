using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Model.Request
{
    public class CreateBookRequest
    {
        [Required]
        public required string Title { get; set; }
        [Required]
        public required string Author { get; set; }
        [Required]
        public required string ISBN { get; set; }
        [Required]
        public required int PublishedYear { get; set; }
    }
}

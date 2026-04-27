using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.DB.Model
{
    public class DBBook
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public required string Title { get; set; }

        [Required]
        [MaxLength(150)]
        public required string Author { get; set; }

        [MaxLength(50)]
        public required string ISBN { get; set; }

        [Range(1000, 9999)]
        public int PublishedYear { get; set; }

        public bool IsAvailable { get; set; }
    }
}

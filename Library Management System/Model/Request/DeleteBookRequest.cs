using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Model.Request
{
    public class DeleteBookRequest
    {
        [Required]
        public required int BookId { get; set; }
    }
}

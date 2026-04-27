using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Model.Request
{
    public class GetBookRequest
    {
        [Required]
        public required int BookId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace FreeApi.Dtos.Comment
{
    public class CreateCommentDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Title must be at least 5 character")]
        [MaxLength(50, ErrorMessage = "Title must be at most 50 character")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(5, ErrorMessage = "Title must be at least 5 character")]
        [MaxLength(50, ErrorMessage = "Title must be at most 50 character")]
        public string Content { get; set; } = string.Empty;
    }
}
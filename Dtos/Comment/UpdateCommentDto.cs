using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FreeApi.Dtos.Comment
{
    public class UpdateCommentDto
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
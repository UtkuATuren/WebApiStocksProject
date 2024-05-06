using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Comment
{
    public class CreateCommentDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Title must be at least 5 characters.")]
        [MaxLength(256, ErrorMessage = "Title cannot be over 256 words.")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(5, ErrorMessage = "Content must be at least 5 characters.")]
        [MaxLength(256, ErrorMessage = "Content cannot be over 256 words.")]
        public string Content { get; set; } = string.Empty;
    }
}

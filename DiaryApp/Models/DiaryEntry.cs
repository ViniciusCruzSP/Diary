using System.ComponentModel.DataAnnotations;

namespace DiaryApp.Models
{
    public class DiaryEntry
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a title!")]
        [StringLength(100, MinimumLength = 3,
            ErrorMessage = "The title must have at least 3 characters!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter a content!")]
        public string Content { get; set; }
        [Required(ErrorMessage = "Please enter a date!")]
        public DateTime Created { get; set; }
    }
}

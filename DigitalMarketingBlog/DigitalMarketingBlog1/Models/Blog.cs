using System.ComponentModel.DataAnnotations;

namespace DigitalMarketingBlog1.Models
{
    public class Blog
    {
        [Display(Name = "Blog Post No")]
        public int Id { get; set; }

        [Display(Name = "Blog Post Name")]
        [Required(ErrorMessage = "Please enter the post name!")]
        [StringLength(100)]
        public string? PostName { get; set; }

        [Display(Name = "Post Date")]
        public string? Date { get; set; }
        [Display(Name = "Post Image")]
        public string? Image { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}

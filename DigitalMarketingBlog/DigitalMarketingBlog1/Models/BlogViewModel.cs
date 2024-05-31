namespace DigitalMarketingBlog1.Models
{
    public class BlogViewModel
    {
        public List<Blog> Blogs { get; set; } = null!;
        public List<Category> Categories { get; set; } = null!;
        public string? SelectedCategory { get; set; }
        public List<Post> Posts { get; set; } = null!;
    }
}

using System.ComponentModel.DataAnnotations;

namespace DigitalMarketingBlog1.Models
{
    public class BlogRegistry
    {
        [Key]
        public int RegistryId { get; set; }
        public int PostId { get; set; }
        public Blog Blog { get; set; } = null!;
        public int BlogId { get; set; }
        public Post Post { get; set; } = null!;
        public DateTime RegistryDate { get; set; }
    }
}

using System.Reflection.Metadata.Ecma335;

namespace DigitalMarketingBlog1.Models
{
    public class Repository
    {
        private static readonly List<Blog> _blogs = new();
        private static readonly List<Category> _categories = new();
        private static readonly List<PostDetails> _postDetails = new();
        private static readonly List<Post> _posts = new();

        static Repository()
        {
            _categories.Add(new Category() { CategoryId = 1, Name = "Technology" });
            _categories.Add(new Category() { CategoryId = 2, Name = "Entrepreneurship" });

            _blogs.Add(new Blog() { Id = 1, PostName = "User Experience Upgrade: UX Improvements in the Transition from No-Code", Date = "09.04.2024", Image = "user.jpg", IsActive = true, CategoryId = 1 });
            _blogs.Add(new Blog() { Id = 2, PostName = "Unlocking the Power of Generative AI: A Guide to Ensuring Data Privacy", Date = "08.04.2024", Image = "unlock.jpg", IsActive = true, CategoryId = 1 });
            _blogs.Add(new Blog() { Id = 3, PostName = "Securing AI : Steps to Ensure Generative AI is Safe and Sound", Date = "07.04.2024", Image = "ai.jpg", IsActive = true, CategoryId = 1 });
            _blogs.Add(new Blog() { Id = 4, PostName = "Revolutionize Your Business with AI SaaS: Top Tools and Technologies", Date = "05.04.2024", Image = "revolutionize.jpg", IsActive = true, CategoryId = 2 });
            _blogs.Add(new Blog() { Id = 5, PostName = "Best Strategies to Build a Startup Team as a Non-tech Founder", Date = "04.04.2024", Image = "1.jpg", IsActive = true, CategoryId = 2 });
            _blogs.Add(new Blog() { Id = 6, PostName = "Top Challenges Faced by Non-tech Founders", Date = "03.04.2024", Image = "best.jpg", IsActive = true, CategoryId = 2 });

            _postDetails.Add(new PostDetails() { Id = 1, Title = "User Experience Upgrade: UX Improvements in the Transition from No-Code", Description = "dlfdlkfd", Image = "1.png" });

        }

        public static List<Blog> Blogs
        {
            get
            {
                return _blogs;
            }
        }

        public static List<Category> Categories
        {
            get
            {
                return _categories;
            }
        }

        public static List<PostDetails> PostDetails
        {
            get
            {
                return _postDetails;
            }
        }

        public static void CreateBlog(Blog entity)
        {
            _blogs.Add(entity);
        }


        public static void EditBlog(Blog updateBlog)
        {
            var entity = _blogs.FirstOrDefault(b => b.Id == updateBlog.Id);
            if (entity != null)
            {
                entity.PostName = updateBlog.PostName;
                entity.Date = updateBlog.Date;
                entity.Image = updateBlog.Image;
                entity.CategoryId = updateBlog.CategoryId;
                entity.IsActive = updateBlog.IsActive;
            }
        }

        public static void DeleteBlog(Blog updateBlog)
        {
            var entity = _blogs.FirstOrDefault(b => b.Id == updateBlog.Id);
            if (entity != null)
            {
                entity.PostName = updateBlog.PostName;
                entity.Date = updateBlog.Date;
                entity.Image = updateBlog.Image;
                entity.CategoryId = updateBlog.CategoryId;
                entity.IsActive = updateBlog.IsActive;
            }
        }



        //public static PostDetails IdAl(int id)
        //{
        //    return _postDetails.FirstOrDefault(PostDetails => PostDetails.Id == id);
        //}


    }
}

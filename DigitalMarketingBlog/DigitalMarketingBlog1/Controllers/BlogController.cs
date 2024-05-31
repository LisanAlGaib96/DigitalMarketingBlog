using DigitalMarketingBlog1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DigitalMarketingBlog1.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index(string searchString, string Category)
        {
            var blogs = Repository.Blogs;
            if (!string.IsNullOrEmpty(searchString))
            {
                ViewBag.searchString = searchString;
                blogs = blogs.Where(b => b.PostName.ToLower().Contains(searchString)).ToList();
            }

            if (!string.IsNullOrEmpty(Category) && Category != "0")
            {
                ViewBag.searchString = searchString;
                blogs = blogs.Where(b => b.CategoryId == int.Parse(Category)).ToList();
            }

            ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
            var model = new BlogViewModel
            {
                Blogs = blogs,
                Categories = Repository.Categories,
                SelectedCategory = Category
            };
            return View(model);


        }

        public IActionResult Create()
        {

            //ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Blog model, IFormFile imageFile)
        {

            var allowedExtension = new[] { ".jpg", ".jpeg", ".png" };
            var extension = Path.GetExtension(imageFile.FileName);
            var randomFile = string.Format($"{Guid.NewGuid().ToString()} {extension}");
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFile);

            if (imageFile != null)
            {
                if (!allowedExtension.Contains(extension))
                {
                    ModelState.AddModelError("", "Please select a picture.");
                }
            }

            if (ModelState.IsValid)
            {
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }
                    model.Image = randomFile;
                    Repository.CreateBlog(model);
                    return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
            return View();
            }
        

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = Repository.Blogs.FirstOrDefault(b => b.Id == id);
            if (entity == null)
            {
                return NotFound();
            }
            ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
            return View(entity);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Blog model, IFormFile? imageFile)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                if (imageFile != null)
                {
                    var extension = Path.GetExtension(imageFile.FileName);
                    var randomFile = string.Format($"{Guid.NewGuid().ToString()} {extension}");
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFile);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }
                    model.Image = randomFile;

                }
                Repository.EditBlog(model);
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
            return View(model);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var blog = Repository.Blogs.FirstOrDefault(b => b.Id == id);
            if (blog == null)
            {
                return NotFound();
            }
            ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
            return View(blog);

        }

        //[HttpPost]
        //public async Task<IActionResult> Delete(int id, Blog model, IFormFile? imageFile)
        //{
        //    if (id != model.Id)
        //    {
        //        return NotFound();
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        if (imageFile != null)
        //        {
        //            var extension = Path.GetExtension(imageFile.FileName);
        //            var randomFile = string.Format($"{Guid.NewGuid().ToString()} {extension}");
        //            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFile);

        //            using (var stream = new FileStream(path, FileMode.Create))
        //            {
        //                await imageFile.CopyToAsync(stream);
        //            }
        //            model.Image = randomFile;

        //        }
        //        Repository.DeleteBlog(model);
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        //    return View(model);
        //}

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            var blog = Repository.Blogs.FirstOrDefault(b => b.Id == id);
            if (blog == null)
            {
                return NotFound();
            }

            Repository.Blogs.Remove(blog);
            return RedirectToAction("Index");
        }

    }
}

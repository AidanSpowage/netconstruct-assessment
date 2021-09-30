using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetC.JuniorDeveloperExam.Web.Controllers
{
    public class BlogPostController : Controller
    {
        readonly IBlogPostRepository blogPostRepository;
        public BlogPostController(IBlogPostRepository repository)
        {
            blogPostRepository = repository;
        }

        // GET: BlogPost
        public ActionResult Index()
        {
            IEnumerable<BlogPost> posts = blogPostRepository.GetAll();
            return View(posts);
        }

        // GET: BlogPost/Blog/5
        public ActionResult Blog(int id)
        {
            BlogPost blogPost = blogPostRepository.GetById(id);
            return View(blogPost);
        }

        [HttpPost]
        [Route("/BlogPost/Blog/{id}/AddComment")]
        public ActionResult AddComment(int id, string commentName, string commentEmailAddress, string commentMessage)
        {
            blogPostRepository.AddComment(id, new BlogPostComment
            {
                Name = commentName,
                EmailAddress = commentEmailAddress,
                Message = commentMessage,
                Date = DateTime.UtcNow
            });

            return RedirectToAction("Blog", id);
        }
    }
}

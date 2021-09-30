using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetC.JuniorDeveloperExam.Web
{
    public interface IBlogPostRepository
    {
        IEnumerable<BlogPost> GetAll();
        BlogPost GetById(int id);
        BlogPost AddComment(int postId, BlogPostComment comment);
    }

    public class BlogPostRepository : IBlogPostRepository
    {
        private List<BlogPost> _blogPosts = new List<BlogPost>();
        private string jsonPath = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Blog-Posts.json");

        public BlogPostRepository()
        {
            LoadBlogPosts();
        }

        private void LoadBlogPosts()
        {
            string json = System.IO.File.ReadAllText(jsonPath);
            _blogPosts = JsonConvert.DeserializeObject<BlogPostRootObject>(json).BlogPosts;
        }

        private void SaveBlogPosts()
        {
            BlogPostRootObject bpro = new BlogPostRootObject();
            bpro.BlogPosts = _blogPosts;
            string json = JsonConvert.SerializeObject(bpro);
            System.IO.File.WriteAllText(jsonPath, json);
        }

        public IEnumerable<BlogPost> GetAll()
            => _blogPosts;

        public BlogPost GetById(int id)
            => _blogPosts.FirstOrDefault(x => id.Equals(x.Id));

        public BlogPost AddComment(int postId, BlogPostComment comment)
        {
            BlogPost blogPost = _blogPosts.FirstOrDefault(x => postId.Equals(x.Id));
            
            if(blogPost != null)
            {
                blogPost.Comments.Add(comment);
                SaveBlogPosts();
            }
            return blogPost;
        }
    }
}

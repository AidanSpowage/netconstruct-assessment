using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetC.JuniorDeveloperExam.Web
{
    public class BlogPost
    {
        public BlogPost()
        {

        }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("htmlContent")]
        public string HtmlContent { get; set; }

        [JsonProperty("comments")]
        public List<BlogPostComment> Comments { get; set; } = new List<BlogPostComment>();
    }
    
    public class BlogPostRootObject
    {
        public BlogPostRootObject()
        {

        }

        [JsonProperty("blogPosts")]
        public List<BlogPost> BlogPosts { get; set; } = new List<BlogPost>();
    }
}
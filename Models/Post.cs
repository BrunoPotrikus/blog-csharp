using Blog.Interfaces;

namespace Blog.Models
{
    public class Post : IPost
    {
        public int Id { get ;set; }
        public Category Category { get; set; }
        public User Author { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public string Slug { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }

        public void CreatePost(Post post)
        {
            
        }

        public void DeletePost(Post post)
        {
            throw new NotImplementedException();
        }

        public void DeletePost(int id)
        {
            throw new NotImplementedException();
        }

        public Post GetPost(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdatePost(Post post)
        {
            throw new NotImplementedException();
        }
    }
}

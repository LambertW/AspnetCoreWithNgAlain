namespace AspNetCore.Api.Models
{
    public class Post
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string Content { get; set; }
    }
}
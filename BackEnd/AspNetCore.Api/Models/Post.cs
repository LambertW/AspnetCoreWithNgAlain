namespace AspNetCore.Api.Models
{
    /// <summary>
    /// Post
    /// </summary>
    public class Post
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// User Id
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// User
        /// </summary>
        public User User { get; set; }
        /// <summary>
        /// Content
        /// </summary>
        public string Content { get; set; }
    }
}
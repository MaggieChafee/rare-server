namespace RareServer.Models
{
    public class PostsData
    {
        public static List<Posts> posts = new()
        {
            new Posts
            {
                Id  = 1,
                UserId = 1,
                CategoryId = 1,
                Title = "Post Test Title",
                PublicationDate = DateTime.Now,
                ImageUrl = "url.com",
                Content = "This is a test post to see if I know what I'm doing.",
                Approved = true
            },
            new Posts
            {
                Id  = 2,
                UserId = 2,
                CategoryId = 1,
                Title = "Post Test Title 2",
                PublicationDate = DateTime.Now,
                ImageUrl = "url.com",
                Content = "This is a test post to see if I know what I'm doing.",
                Approved = true
            },
        };
    }
}

namespace RareServer.Models
{
    public class PostData
    {
        public static List<Posts> posts = new()
        {
            new Post
            {
                Id = 1,
                UserId = 1,
                CategoryId = 1,
                Title = "Welcome To My Blog",
                PublicationDate = new DateTime(2023, 04, 02),
                ImageUrl = "test url",
                Content = "this is a test",
                Approved = true,
            },
            new Posts
            {
                Id = 2,
                UserId = 2,
                CategoryId = 2,
                Title = "All About Me",
                PublicationDate = new DateTime(2023, 04, 02),
                ImageUrl = "test url",
                Content = "this is a test",
                Approved = true,
            },
            new Posts
            {
                Id = 3,
                UserId = 3,
                CategoryId = 3,
                Title = "What I Do For Living ",
                PublicationDate = new DateTime(2023, 04, 02),
                ImageUrl = "test url",
                Content = "this is a test",
                Approved = true,
            },
            new Posts
            {
                Id = 4,
                UserId = 3,
                CategoryId = 4,
                Title = "Top 10 Ways To Improve Yourself",
                PublicationDate = new DateTime(2023, 04, 02),
                ImageUrl = "test url",
                Content = "this is a test",
                Approved = true,
            },
            new Posts
            {
                Id = 1,
                UserId = 2,
                CategoryId = 1,
                Title = "Top 10 Ways To Improve Your Thinking",
                PublicationDate = new DateTime(2023, 04, 02),
                ImageUrl = "test url",
                Content = "this is a test",
                Approved = true,
            },
        };
    }
}




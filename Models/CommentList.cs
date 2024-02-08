namespace RareServer.Models
{
    public class CommentList
    {
        public static List<Comments> comments = new()
        {
            new Comments
            {
                Id = 1,
                AuthorId = 1,
                PostId = 1,
                Content = "This is so COOL!"
            },
            new Comments
            {
                Id = 2,
                AuthorId = 2,
                PostId = 1,
                Content = ":) nice job."
            },
            new Comments
            {
                Id = 3,
                AuthorId = 1,
                PostId = 2,
                Content = "WOWWWW!"
            }
        };
    }
}

namespace RareServer.Models
{
    public class PostTagsData
    {
        public static List<PostTags> postTags = new()
        {
            new PostTags
            {
                Id = 1,
                TagId = 1,
                PostId = 1,
            },
            new PostTags
            {
                Id = 2,
                TagId = 4,
                PostId = 1,
            },
            new PostTags
            {
                Id = 3,
                TagId = 3,
                PostId = 2,
            }
        };
    }
}
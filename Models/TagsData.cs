namespace RareServer.Models
{
    public class TagsData
    {
        public static List<Tag> tags = new List<Tag>
        {
            new Tag { Id = 1, Label = "The Latest" },
            new Tag { Id = 2, Label = "News"},
            new Tag { Id = 3, Label = "Books & Culture"},
            new Tag { Id = 4, Label = "Fiction & Poetry"},
            new Tag { Id = 5, Label = "Humor & Cartoons"}
        };
    }
}

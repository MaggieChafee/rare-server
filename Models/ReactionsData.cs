namespace RareServer.Models
{
    public class ReactionsData
    {
        public static List<Reactions> reactions = new()
        {
            new Reactions
            {
                Id = 1,
                Emoji = "Happy",
            },
            new Reactions
            {
                Id = 2,
                Emoji = "Sad",
            },
            new Reactions
            {
                Id = 3,
                Emoji = "Silly",
            },
            new Reactions
            {
                Id = 4,
                Emoji = "Mad",
            },
        };
    }
}

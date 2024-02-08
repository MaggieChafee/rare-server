namespace RareServer.Models
{
    public class Subscription
    {
        public static List<Subscriptions> subscriptions = new()
        {
            new Subscriptions()
            {
                Id = 1,
                FollowerId = 1,
                AuthorId = 1,
                CreatedOn = new DateTime(2024, 02, 03)
            },
            new Subscriptions()
            {
                Id = 2,
                FollowerId = 1,
                AuthorId = 3,
                CreatedOn = new DateTime(2024, 02, 03)
            },
            new Subscriptions()
            {
                Id = 3,
                FollowerId = 4,
                AuthorId = 2,
                CreatedOn = new DateTime(2024, 02, 03)
            }
        };
    }
}

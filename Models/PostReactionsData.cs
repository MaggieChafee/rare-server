namespace RareServer.Models
{
	public class PostReactionsData
	{
		public static List<PostReactions> postReactions = new()
		{
			new PostReactions
			{
				Id = 1,
				ReactionId = 1,
				UserId = 1,
				PostId = 1,
			},
            new PostReactions
            {
                Id = 2,
                ReactionId = 2,
                UserId = 2,
                PostId = 2,
            },
            new PostReactions
            {
                Id = 3,
                ReactionId = 3,
                UserId = 3,
                PostId = 3,
            },
            new PostReactions
            {
                Id = 4,
                ReactionId = 4,
                UserId = 4,
                PostId = 4,
            },
               new PostReactions
            {
                Id = 4,
                ReactionId = 4,
                UserId = 4,
                PostId = 2,
            },
        };
	}
}


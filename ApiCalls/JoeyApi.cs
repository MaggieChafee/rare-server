using RareServer.Models;

namespace RareServer.ApiCalls
{
    public static class JoeyApi
    {
        public static void Map(WebApplication app)
        {

            //getAllReactions***
            app.MapGet("/reactions", () =>
            {
                return ReactionsData.reactions;
            });

            //getSingleReaction by id***
            app.MapGet("/reactions/{id}", (int id) =>
            {
                Reactions reaction = ReactionsData.reactions.FirstOrDefault(reaction => reaction.Id == id);
                if (reaction == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(reaction);
            });

            //getPostReactionsByPostId [include getReactionsByReactionsId]***
            app.MapGet("/posts/{id}/postreactions", (int id) =>
            {
                List<PostReactions> postReactionList = PostReactionsData.postReactions.Where(pr => pr.PostId == id).ToList();
                if (postReactionList == null)
                {
                    return Results.NotFound();
                }

                foreach (PostReactions pReact in postReactionList)
                {
                    pReact.Reaction = ReactionsData.reactions.FirstOrDefault(r => r.Id == pReact.ReactionId);
                }
               
                return Results.Ok(postReactionList);
            });

            //getSinglePostReaction by id [include getReactionsByReactionsId & getUserByUserId]***
            app.MapGet("/postreactions/{id}", (int id) =>
            {
                PostReactions pReaction = PostReactionsData.postReactions.FirstOrDefault(pr => pr.Id == id);
                if (pReaction == null)
                {
                    return Results.NotFound();
                }

                pReaction.Reaction = ReactionsData.reactions.FirstOrDefault(r => r.Id == pReaction.ReactionId);

                return Results.Ok(pReaction);
            });

            //createPostReaction***
            app.MapPost("/postreactions/new", (PostReactions postReaction) =>
            {
                postReaction.Id = PostReactionsData.postReactions.Max(pr => pr.Id) + 1;
                PostReactionsData.postReactions.Add(postReaction);
                return postReaction;
            });

            //deletePostReaction***
            app.MapDelete("/postreactions/delete/{id}", (int id) =>
            {
                PostReactions pReact = PostReactionsData.postReactions.FirstOrDefault(pr => pr.Id == id);
                if (pReact == null)
                {
                    return Results.NotFound();
                }
                PostReactionsData.postReactions.Remove(pReact);
                return Results.NoContent();
            });

            //getAllPosts
            app.MapGet("/posts", () =>
            {
                return PostData.posts;
            });

            //getUsersPosts - userId
            app.MapGet("/posts/user/{id}", (int id) =>
            {
                List<Posts> userPostList = PostData.posts.Where(p => p.UserId == id).ToList();
                if (userPostList == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(userPostList);

            });

            //deletePost - postId
            app.MapDelete("/posts/delete/{id}", (int id) =>
            {
                Posts deletePost = PostData.posts.FirstOrDefault(p => p.Id == id);
                if (deletePost == null)
                {
                    return Results.NotFound();
                }

                PostData.posts.Remove(deletePost);
                return Results.NoContent();
            });

            //search by post title

            app.MapGet("/posts/search/{title}", (string title) =>
            {

                List<Posts> resultList = PostData.posts.Where(p => p.Title.ToLower().Contains(title.ToLower().Trim())).ToList();
                if (resultList == null)
                {
                    return Results.NoContent();
                }

                return Results.Ok(resultList);
            });
        }
    }
}

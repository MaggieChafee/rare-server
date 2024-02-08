using RareServer.Models;


namespace RareServer.ApiCalls
{
    public static class GregApi
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/user", () => //get all users
            {
                return UserList.users;
            });

            app.MapGet("/user/{id}", (int id) => //get a single user
            {
                Users user = UserList.users.FirstOrDefault(u => u.Id == id);
                if (user == null)
                {
                    return Results.NotFound("There are no users that match the Id given.");
                }
                return Results.Ok(user);
            });

            app.MapGet("/posts/{postId}/comments", (int postId) => //show comments of a specific post
            {
               List<Comments> postsComments = CommentList.comments.Where(c => c.PostId == postId).ToList();
                if (postsComments == null)
                {
                    return Results.NotFound("This post has no comments on it yet.");
                }    
                return Results.Ok(postsComments);
            });

            app.MapDelete("/posts/{postId}/comments/{id}", (int id) => //delete a comment from a post
            {
                Comments commentToDelete = CommentList.comments.Where(c => c.Id == id).FirstOrDefault();
                if(commentToDelete == null)
                {
                    return Results.NotFound("There was an issue deleting this comment.");
                }
                CommentList.comments.Remove(commentToDelete);
                return Results.Ok(commentToDelete);
            });

            app.MapPost("/posts/{id}/comments", (Comments comment) => //create a comment
            {
                try
                {
                    if (CommentList.comments == null) 
                    {
                        comment.Id = 1;
                        CommentList.comments.Add(comment);
                        return Results.Ok(comment);
                    }
                    else
                    {
                        comment.Id = CommentList.comments.Max(c => c.Id) + 1; 
                        CommentList.comments.Add(comment);
                        return Results.Ok(comment);
                    }
                }
                catch (Exception)
                { 
                    return Results.NotFound("Something went wrong, please try again.");
                }
            });
       
                

            app.MapPut("posts/{id}/comments", (int authorId, Comments updatedComment) => //edit a comment
            {
                Comments commentToUpdate = CommentList.comments.FirstOrDefault(c => c.Id == authorId);

                commentToUpdate.Content = updatedComment.Content;

                if (commentToUpdate == null)
                {
                    return Results.NotFound("There was an issue editing your comment please try again.");
                }
                return Results.Ok(commentToUpdate);

            });



        }
    }
}

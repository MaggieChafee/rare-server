using RareServer.Models;
using System.Xml.Linq;


namespace RareServer.ApiCalls
{
    public static class GregApi
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/user", () =>
            {
                return UserList.users;
            });

            app.MapGet("/user/{id}", (int id) =>
            {
                Users user = UserList.users.FirstOrDefault(u => u.Id == id);
                if (user == null)
                {
                    return Results.NotFound("There are no users that match the Id given.");
                }
                return Results.Ok(user);
            });

            app.MapGet("/posts/{id}", (int idOfPost) =>
            {
               List<Comments> postsComments = CommentList.comments.Where(c => c.PostId == idOfPost).ToList();
                if (postsComments == null)
                {
                    return Results.NotFound("This post has no comments on it yet.");
                }    
                return Results.Ok(postsComments);
            });

            app.MapDelete("/posts/${id}", (int idOfComment) =>
            {
                Comments commentToDelete = CommentList.comments.Where(c => c.Id == idOfComment).FirstOrDefault();
                if(commentToDelete == null)
                {
                    return Results.NotFound("There was an issue deleting this comment.");
                }
                CommentList.comments.Remove(commentToDelete);
            });

        }
    }
}

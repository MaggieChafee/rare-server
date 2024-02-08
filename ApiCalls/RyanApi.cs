using RareServer.Models;

namespace RareServer.ApiCalls
{
    public static class RyanApi
    {
        public static void Map(WebApplication app)
        {
            // Subscribe API Calls
            app.MapGet("/user/{id}/subscriptions", (int id) =>
            {
                var userSubscriptions = Subscription.subscriptions.Where(s => id == s.FollowerId).ToList();

                return Results.Ok(userSubscriptions);
            });
            // Author         // Follower
            app.MapPost("/user/{id}/subscribe/{uid}", (int id, int uid) =>
            {
                var user = UserList.users.FirstOrDefault(u => u.Id == uid).Id;
                Subscriptions subscribe = Subscription.subscriptions.FirstOrDefault(s => s.AuthorId == id);

                subscribe.Id = Subscription.subscriptions.Max(s => s.Id) + 1;
                subscribe.AuthorId = id;
                subscribe.FollowerId = user;
                subscribe.CreatedOn = DateTime.Today;

                return Results.Ok();
            });

            app.MapDelete("/subscriptions/{id}/unsubscribe", (int id) =>
            {
                Subscriptions unsubscribe = Subscription.subscriptions.FirstOrDefault(s => s.Id == id);
                Subscription.subscriptions.Remove(unsubscribe);

                return Results.Ok();
            });

            // Categories API Calls
            app.MapGet("/categories", () =>
            {
                return Category.categories;
            });

            app.MapGet("/categories/{id}", () =>
            {

            });

            app.MapPost("/categories", () =>
            {

            });
        }
    }
}

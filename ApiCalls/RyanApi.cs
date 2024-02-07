using RareServer.Models;

namespace RareServer.ApiCalls
{
    public static class RyanApi
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/user/{id}/subscriptions", (int id) =>
            {
                var userSubscriptions = Subscription.subscriptions.Where(s => s.FollowerId == id);

                return Results.Ok(Subscription.subscriptions);
            });

            app.MapPost("/user/{id}/subscribe", (int id) =>
            {
                Subscriptions subscribe = Subscription.subscriptions.FirstOrDefault(s => s.Id == id);
                subscribe.AuthorId = id;
                subscribe.CreatedOn = DateTime.Today;
                subscribe.Id = Subscription.subscriptions.Max(s => s.Id) + 1;

                Subscription.subscriptions.Add(subscribe);

                return Results.Ok(Subscription.subscriptions);
            });

            app.MapDelete("/user/{uid}/subscriptions/{id}", (int uid, int id) => 
            {
                var userUnsubscribe = UserList.users
                    .FirstOrDefault(u => u.Id == uid);
                var unsubscribe = Subscription.subscriptions.FirstOrDefault(s => s.Id == id);
                Subscription.subscriptions.Remove(unsubscribe);

                return Results.Ok();
            });
        }
    }
}

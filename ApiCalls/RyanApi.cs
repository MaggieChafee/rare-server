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

            app.MapPost("/user/{id}/subscribe", (Subscriptions subscriptions, int id) =>
            {

                subscriptions.Id = Subscription.subscriptions.Max(s => s.Id) + 1;
                Subscription.subscriptions.Add(subscriptions);



                return Subscription.subscriptions;
            });

            // app.MapDelete();
        }
    }
}

﻿using RareServer.Models;


namespace RareServer.ApiCalls
{
    public static class GregApi
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("rare/user", () =>
            {
                return UserList.users;
            });

            app.MapGet("rare/user/{id}", (int id) =>
            {
                Users user = UserList.users.FirstOrDefault(u => u.Id == id);
                if (user == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(user);
            }
            );
        }
    }
}

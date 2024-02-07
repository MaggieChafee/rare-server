using RareServer.Models;

namespace RareServer.ApiCalls

{
    public static class MaggieApi
    {
        public static void Map(WebApplication app)
        {
            // getAllTags
            app.MapGet("/tags", () =>
            {
                return Results.Ok(TagsData.tags);
            });

            // getAllPostsTags
            // updateTag
            // createTag
            app.MapPost("/tags", (Tag newTag) =>
            {
                newTag.Id = TagsData.tags.Count + 1;
                TagsData.tags.Add(newTag);
                return Results.Ok(newTag);
            });

            // deleteTag
            app.MapDelete("/tags/{id}", (int id) =>
            {
                Tag deleteTag = TagsData.tags.FirstOrDefault(t => t.Id == id);
                if (deleteTag == null)
                {
                    return Results.NotFound();
                } 
                TagsData.tags.Remove(deleteTag);
                return Results.Ok();
            });
        }
    }
}

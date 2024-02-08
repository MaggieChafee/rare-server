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
                List<Tag> alphabetizedTags = TagsData.tags.OrderBy(t => t.Label).ToList();
                if (alphabetizedTags == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(alphabetizedTags);
            });

            // getAllPostsTags - get tags associate with a post
            app.MapGet("/posts/{postId}/tags", (int postId) =>
            {
                Posts singlePost = PostsData.posts.FirstOrDefault(post => post.Id == postId);
                if (singlePost == null) 
                {
                    return Results.NotFound();
                }
                List<PostTags> getPostTags = PostTagsData.postTags.Where(pt => pt.PostId == singlePost.Id).ToList();
                List<int> tagId = getPostTags.Select(pt => pt.TagId).ToList();
                List<Tag> labels = TagsData.tags.Where(t => tagId.Contains(t.Id)).ToList();
                return Results.Ok(labels);
            });

            // updateTag
            app.MapPut("/tags/{id}", (int id, Tag updateTag) =>
            {
                Tag tagToUpdate = TagsData.tags.FirstOrDefault(t => t.Id == id);
                int tagIndex = TagsData.tags.IndexOf(tagToUpdate);
                if (tagToUpdate == null) 
                { 
                    return Results.NotFound();
                }
                return Results.Ok(TagsData.tags[tagIndex]);
            });

            // createTag
            app.MapPost("/tags", (Tag newTag) =>
            {
                newTag.Id = TagsData.tags.Max(t => t.Id) + 1;
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

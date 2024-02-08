using Microsoft.Extensions.Hosting;
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

            // getAllPostsTags - gets all tags associated with a post
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

            // getPostTagsByPostId(include getPostByPostId and getUserByUserId)
            app.MapGet("/posts/{postId}/postTags", (int postId) =>
            {
                Posts singlePost = PostsData.posts.FirstOrDefault(post => post.Id == postId);
                if (singlePost == null)
                {
                    return Results.NotFound();
                }
                List<PostTags> getPostTags = PostTagsData.postTags.Where(pt => pt.PostId == singlePost.Id).ToList();
                return Results.Ok(getPostTags);
            });

            // getSinglePostTagById(include getTagByTagId and getUserByUserId)
            app.MapGet("/postTags/{id}", (int id) =>
            {
                PostTags singlePostTag = PostTagsData.postTags.FirstOrDefault(pt => pt.Id == id);
                if (singlePostTag == null)
                {
                    return Results.NotFound(); 
                }
                return Results.Ok(singlePostTag);
            });

            // getSingleTagByPostTagId - gets a single tag by postTagId
            app.MapGet("/postTags/{id}/tag", (int id) =>
            {
                PostTags singlePostTag = PostTagsData.postTags.FirstOrDefault(pt => pt.Id == id);
                Tag singleTag = TagsData.tags.FirstOrDefault(t => t.Id == singlePostTag.TagId);
                if (singleTag == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(singleTag);
            });

            // createPostTags(POST)
            app.MapPost("/postTags", (PostTags newPostTag) =>
            {
                newPostTag.Id = PostTagsData.postTags.Max(t => t.Id) + 1;
                PostTagsData.postTags.Add(newPostTag);
                return Results.Ok(newPostTag);
            });

            // deletePostTags(DELETE)
            app.MapDelete("/postTags/{id}", (int id) =>
            {
                PostTags deletePostTag = PostTagsData.postTags.FirstOrDefault(t => t.Id == id);
                if (deletePostTag == null)
                {
                    return Results.NotFound();
                }
                PostTagsData.postTags.Remove(deletePostTag);
                return Results.Ok();
            });

            // updatePostTags(PUT)
            app.MapPut("/postTags/{id}", (int id, PostTags updatePostTag) =>
            {
                PostTags pTagToUpdate = PostTagsData.postTags.FirstOrDefault(t => t.Id == id);
                int pTagIndex = PostTagsData.postTags.IndexOf(pTagToUpdate);
                if (pTagToUpdate == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(PostTagsData.postTags[pTagIndex]);
            });
        }
    }
}

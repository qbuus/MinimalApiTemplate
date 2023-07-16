using Application.Posts.Commands;
using Application.Posts.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.Extensions.Hosting;
using MinimalApi.Abstractions;

namespace MinimalApi.EndpointDefinitions
{
    public class PostEndpointDefinition : IEndpointDefinition
    {
        public void RegisterEndpoints(WebApplication app)
        {
            var posts = app.MapGroup("/api/posts");

            posts.MapGet("/{id}", GetPostById).WithName("GetPostById");

            posts.MapPost("/", CreatePost);

            posts.MapGet("/", GetAllPosts);

            posts.MapPut("/{id}", UpdatePost);

            posts.MapDelete("/{id}", DeletePost);
        }

        private async Task<IResult> GetPostById(IMediator mediator, int id)
        {
            var getPost = new GetPostById { Id = id };
            var post = await mediator.Send(getPost);
            return TypedResults.Ok(post);
        }

        private async Task<IResult> CreatePost(IMediator mediator, Post post)
        {
            var createPost = new CreatePost { PostContent = post.Content };
            var createdPost = await mediator.Send(createPost);
            return Results.CreatedAtRoute("GetPostById", new { createdPost.Id }, createdPost);
        }

        private async Task<IResult> GetAllPosts(IMediator mediator)
        {
            var postsCommand = new GetAllPosts();
            var posts = await mediator.Send(postsCommand);
            return TypedResults.Ok(posts);
        }

        private async Task<IResult> UpdatePost(IMediator mediator,Post post, int id, )
        {
            var updatePost = new UpdatePost { Id = id, Content = post.Content };
            var updatedPost = await mediator.Send(updatePost);
            return TypedResults.Ok(updatedPost);
        }
        private async Task<IResult> DeletePost(IMediator mediator, int id)
        {
            var deletePostById = new DeletePost { Id = id };
            await mediator.Send(deletePostById);
            return TypedResults.NoContent();
        }
    }
}

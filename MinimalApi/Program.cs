using Application.Abstractions;
using Application.Posts.Commands;
using DataAccess;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Application.Posts.Queries;
using Microsoft.AspNetCore.Http.HttpResults;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

var cs = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<SocialDbContext>(opt => opt.UseSqlServer(cs));
builder.Services.AddScoped<IPostsRepository, PostRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(CreatePost)));

var app = builder.Build();

// middleware area

app.UseHttpsRedirection();

// route area
app.MapGet("/api/posts/{id}", async(IMediator mediator, int id) =>
{
    var getPost = new GetPostById { Id = id };
    var post = await mediator.Send(getPost);
    return Results.Ok(post);
}).WithName("GetPostById");

app.MapPost("/api/posts", async(IMediator mediator, Post post) =>
{
    var createPost = new CreatePost { PostContent = post.Content };
    var createdPost = await mediator.Send(createPost);
    return Results.CreatedAtRoute("GetPostById", new { createdPost.Id }, createdPost);
});

app.MapGet("api/posts", async (IMediator mediator) =>
{
    var postsCommand = new GetAllPosts();
    var posts = await mediator.Send(postsCommand);
    return Results.Ok(posts);
});

app.MapPut("api/post/{id}", async (IMediator mediator, Post post, int id) =>
{
    var updatePost = new UpdatePost { Id = id, Content = post.Content };
    var updatedPost = await mediator.Send(updatePost);  
    return Results.Ok(updatedPost);
});

app.MapDelete("/api/posts/{id}", async (IMediator mediator, int id) =>
{
    var deletePostById = new DeletePost { Id = id };
    await mediator.Send(deletePostById);
    return Results.NoContent();
});

app.Run();


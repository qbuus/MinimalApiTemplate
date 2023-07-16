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
using MinimalApi.Extensions;

// builder area
var builder = WebApplication.CreateBuilder(args);
builder.RegisterServices();

var app = builder.Build();

// middleware area
app.Use(async (context, next) =>
{
    try 
    {
        await next();
    }
    catch 
    {
        context.Response.StatusCode = 500;
        await context.Response.WriteAsync("An error occured");
    }
});


app.UseHttpsRedirection();

// route area
app.RegisterEndpointDefinition();


app.Run();


using MediatR;
using Microsoft.EntityFrameworkCore;
using Violinews.Commands;
using Violinews.Models;
using Violinews.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ViolinewsContext>(opt => opt.UseInMemoryDatabase("violinews"));



builder.Services.AddMediatR(new Type[]
{
    typeof(AddNewPostCommand),
    typeof(GetPostQuery)
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

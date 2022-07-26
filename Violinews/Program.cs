using MediatR;
using Microsoft.EntityFrameworkCore;
using Violinews;
using Violinews.Commands;
using Violinews.Models;
using Violinews.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ViolinewsContext>(opt => opt.UseInMemoryDatabase("violinews"));
builder.Services.AddCors(options => options.AddPolicy("AllowAnyOrigin", policy =>
{
    policy.AllowAnyOrigin();
    policy.AllowAnyMethod();
    policy.AllowAnyHeader();
}));

builder.Services.AddMediatR(new Type[]
{
    typeof(AddNewPostCommand),
    typeof(GetPostQuery),
    typeof(AddNewPostCommand)
});

builder.Services.AddHealthChecks();

builder.Services.AddSignalR();

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
app.UseCors("AllowAnyOrigin");
app.UseAuthorization();

app.MapControllers();

app.MapHub<PostHub>("/postHub");
app.MapHealthChecks("/health");
app.Run();

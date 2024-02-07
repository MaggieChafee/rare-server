using RareServer.ApiCalls;
using RareServer.Models;

var builder = WebApplication.CreateBuilder(args);

List<Tag> tags = new List<Tag>
{
    new Tag { Id = 1, Label = "The Latest" },
    new Tag { Id = 2, Label = "News"},
    new Tag { Id = 3, Label = "Books & Culture"},
    new Tag { Id = 4, Label = "Fiction & Poetry"},
    new Tag { Id = 5, Label = "Humor & Cartoons"}
};

// Add services to the container.

builder.Services.AddControllers();
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

MaggieApi.Map(app);

app.Run();

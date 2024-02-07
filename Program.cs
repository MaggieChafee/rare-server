using RareServer.ApiCalls;
using RareServer.Models;

List<Subscriptions> subscriptions = new()
{
    new Subscriptions()
    {
        Id = 1,
        FollowerId = 1,
        AuthorId = 1,
        CreatedOn = new DateTime(2024, 02, 03)
    }
};

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

GregApi.Map(app);
RyanApi.Map(app);

app.Run();

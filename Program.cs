using RareServer.ApiCalls;
using RareServer.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// add CORS here
// extra line: .AllowAnyHeader().AllowAnyMethod();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// app UseCors('enter variable name here");

app.UseAuthorization();

app.MapControllers();


GregApi.Map(app);
RyanApi.Map(app);
JoeyApi.Map(app);
MaggieApi.Map(app);
<<<<<<< HEAD
=======

>>>>>>> main

app.Run();

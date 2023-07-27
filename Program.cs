using Exercise1.Hubs;
using Exercise1.Models;
using Exercise1.Services;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<TrafficLightService>();
builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowCors",

        policy =>

        {

            policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();

        }

        );

});

// Other configuration...

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowCors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<TrafficLightHub>("/trafficLightHub");

app.Run();
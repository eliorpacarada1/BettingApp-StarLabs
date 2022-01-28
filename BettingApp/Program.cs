using System.Reflection;
using BettingApp.Data;
using BettingApp.Models;
using BettingApp.Repositories;
using BettingApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Swagger configuration
builder.Services.AddSwaggerGen(cfg =>
{
    cfg.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Swagger API",
        Description = "Bet API crud",
        Version = "v1"
    });
    var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var filePath = Path.Combine(AppContext.BaseDirectory, fileName);
    cfg.IncludeXmlComments(filePath);
});

builder.Services.AddAutoMapper(typeof(Bet));

builder.Services.AddTransient<IBetRepository, BetRepository>();

builder.Services.AddTransient<IBetService, BetService>();


var connectionString = builder.Configuration.GetConnectionString("MyWebApiConection");
builder.Services.AddDbContext<MyWebApiContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(cfg =>
    {
        cfg.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//registering our AppDbContext so it can be handed to any class that asks for it
//UseSqlite means our database is a single file on disk (app.db)
//the connection string "DatabaseConnection" is read from appsettings.json
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DatabaseConnection")));


//everything above registers services. Build() creates the app
//everything below sets up what happens with each request
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//sends any http:// request over to https://
app.UseHttpsRedirection();

//checks [Authorize] attributes. We don't have any yet, but it comes baked in
app.UseAuthorization();

//this connects each controllers routes, like api/movies
app.MapControllers();

//start the server and wait for requests
app.Run();

using TodoApi.Services;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

// https://medium.com/@saisiva249/how-to-configure-postgres-database-for-a-net-a2ee38f29372

var builder = WebApplication.CreateBuilder(args);
// var connectionString = builder.Configuration.GetConnectionString("TodoDB") ?? "Data Source=Todo.db";

var Configuration = builder.Configuration;
builder.Services.AddDbContext<TodoContext>(options =>
        options.UseNpgsql(Configuration.GetConnectionString("TodoDB")));

// Add services to the container.

builder.Services.AddControllers();
// builder.Services.AddSqlServer<TodoContext>(connectionString);

// builder.Services.AddDbContext<TodoContext>(opt =>
//     opt.UseInMemoryDatabase("TodoItem"));
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

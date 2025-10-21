using Microsoft.EntityFrameworkCore;
using NBPTableApi.AppDbContext;
using NBPTableApi.Services;
using NBPTableApi.Workers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContextSqlite>(options =>
    options.UseSqlite("Data Source=NBPTableProjectDatabase.db"));
builder.Services.AddHttpClient<INBPService, NBPService>();
builder.Services.AddHostedService<NBPWorker>();

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

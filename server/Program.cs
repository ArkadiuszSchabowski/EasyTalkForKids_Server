using EasyTalkForKids.Interfaces;
using EasyTalkForKids.Models;
using EasyTalkForKids.Repositories;
using EasyTalkForKids.Services;
using EasyTalkForKids_Database;
using EasyTalkForKids_Database.Entities;
using EasyTalkForKids_Server.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EasyTalkConnectionString"));
});


builder.Services.AddScoped<IService<WordDto>, WordService>();
builder.Services.AddScoped<IService<LessonDto>, LessonService>();

builder.Services.AddScoped<IRepository<Word>, WordRepository>();
builder.Services.AddScoped<IRepository<Lesson>, LessonRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseStaticFiles();

app.UseCors("CorsPolicy");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

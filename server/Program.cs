using EasyTalkForKids.Interfaces;
using EasyTalkForKids.Middleware;
using EasyTalkForKids.Models;
using EasyTalkForKids.Repositories;
using EasyTalkForKids.Services;
using EasyTalkForKids_Database;
using EasyTalkForKids_Database.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<ErrorHandlingMiddleware>();

builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EasyTalkConnectionString"));
});


builder.Services.AddScoped<IAddService<AddCategoryDto>, CategoryService>();
builder.Services.AddScoped<IGetService<GetCategoryDto>, CategoryService>();
builder.Services.AddScoped<IRemoveService<RemoveCategoryDto>, CategoryService>();

builder.Services.AddScoped<IAddService<AddLessonDto>, LessonService>();
builder.Services.AddScoped<IGetService<GetLessonDto>, LessonService>();
builder.Services.AddScoped<IRemoveService<RemoveLessonDto>, LessonService>();

builder.Services.AddScoped<IAddService<AddTopicDto>, TopicService>();
builder.Services.AddScoped<IGetService<GetTopicDto>, TopicService>();
builder.Services.AddScoped<IRemoveService<RemoveTopicDto>, TopicService>();

builder.Services.AddScoped<IAddService<AddWordDto>, WordService>();
builder.Services.AddScoped<IGetService<GetWordDto>, WordService>();
builder.Services.AddScoped<IRemoveService<RemoveWordDto>, WordService>();

builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();
builder.Services.AddScoped<IRepository<Lesson>, LessonRepository>();
builder.Services.AddScoped<IRepository<Word>, WordRepository>();
builder.Services.AddScoped<IRepository<Topic>, TopicRepository>();

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

app.UseMiddleware<ErrorHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

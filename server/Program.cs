using EasyTalkForKids.Interfaces;
using EasyTalkForKids.Middleware;
using EasyTalkForKids.Models;
using EasyTalkForKids.Repositories;
using EasyTalkForKids.Services;
using EasyTalkForKids.Validators;
using EasyTalkForKids_Database;
using EasyTalkForKids_Database.Entities;
using Microsoft.AspNetCore.Mvc;
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

builder.Services.AddScoped<IAddService<AddWordDto>, WordService>();
builder.Services.AddScoped<IGetService<GetWordDto>, WordService>();
builder.Services.AddScoped<IRemoveService<RemoveWordDto>, WordService>();

builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();
builder.Services.AddScoped<IRepository<Lesson>, LessonRepository>();
builder.Services.AddScoped<IRepository<Word>, WordRepository>();

builder.Services.AddScoped<IRepositoryCategory, CategoryRepository>();

builder.Services.AddScoped<ICategoryValidator, CategoryValidator>();
builder.Services.AddScoped<IValidator, Validator>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
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

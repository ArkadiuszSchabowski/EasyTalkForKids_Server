using EasyTalkForKids.Interfaces;
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

builder.Services.AddScoped<IWord, WordService>();

builder.Services.AddScoped<IRepository<Word>, WordRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

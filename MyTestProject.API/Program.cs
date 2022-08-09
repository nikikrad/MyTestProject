using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyTestProject.API.AutoMapper;
using MyTestProject.BLL.Entities;
using MyTestProject.BLL.Repositories;
using MyTestProject.BLL.Services;
using MyTestProject.BLL.Services.Interfaces;
using MyTestProject.BLL.UnitOfWork;
using MyTestProject.DAL;
using MyTestProject.DAL.Repositories;
using MyTestProject.DAL.UnitOfWork;
using MyTestProject.DAL.Finder;
using MyTestProject.BLL.Finder;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(GameProfile));
builder.Services.AddScoped<IGameFinder, GameFinder>();
builder.Services.AddScoped<IRepository<Game>, Repository<Game>>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped <IGameService, GameService> ();

builder.Services.AddDbContext<StoreContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

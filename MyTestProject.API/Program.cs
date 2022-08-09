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

builder.Services.AddDbContext<StoreContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(GameProfile), typeof(PlayerProfile), typeof(PCProfile), typeof(OSProfile));

builder.Services.AddScoped<IOSFinder, OSFinder>();
builder.Services.AddScoped<IOSService, OSService>();
builder.Services.AddScoped<IRepository<OS>, Repository<OS>>();
builder.Services.AddScoped<DbSet<OS>>((t => t.GetRequiredService<StoreContext>().OSs));
builder.Services.AddScoped<IPCService, PCService>();
builder.Services.AddScoped<IPCFinder, PCFinder>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IPlayerFinder, PlayerFinder>();
builder.Services.AddScoped<DbSet<Game>>(t => t.GetRequiredService<StoreContext>().Games);
builder.Services.AddScoped<DbSet<Player>>(t => t.GetRequiredService<StoreContext>().Players);
builder.Services.AddScoped<DbSet<PC>>(t => t.GetRequiredService<StoreContext>().PCs);
builder.Services.AddScoped<IGameFinder, GameFinder>();
builder.Services.AddScoped<IRepository<Game>, Repository<Game>>();
builder.Services.AddScoped<IRepository<Player>, Repository<Player>>();
builder.Services.AddScoped<IRepository<PC>, Repository<PC>>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped <IGameService, GameService> ();


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

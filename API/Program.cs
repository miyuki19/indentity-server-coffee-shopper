using API.Services;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

DotNetEnv.Env.Load();

string db_conn_str = Environment.GetEnvironmentVariable("DB_CONNECTION");

builder.Services.AddControllers();

builder.Services.AddScoped<ICoffeeShopService, CoffeeShopService>();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(db_conn_str));

var app = builder.Build();

app.MapControllers();

app.Run();

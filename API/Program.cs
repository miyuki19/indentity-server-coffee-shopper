using API.Services;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

DotNetEnv.Env.Load();

string db_conn_str = Environment.GetEnvironmentVariable("DB_CONNECTION");
string authority_url = Environment.GetEnvironmentVariable("AUTHORITY_URL");

builder.Services.AddControllers();

builder.Services.AddAuthentication("Bearer")
    .AddIdentityServerAuthentication("Bearer", options => {
        options.Authority = authority_url;
        options.ApiName = "CoffeeAPI";
    });

builder.Services.AddScoped<ICoffeeShopService, CoffeeShopService>();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(db_conn_str));

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

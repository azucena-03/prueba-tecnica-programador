using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;
using TrabajadoresPrueba.Persistence;
using TrabajadoresPrueba.Repositories.Abstract;
using TrabajadoresPrueba.Repositories.Implementation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddOptions();
builder.Services.Configure<ConnectionConfiguration>(builder.Configuration.GetSection("ConnectionStrings"));
//builder.Services.AddTransient<IDbConnection>(options => new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IFactoryConnection, FactoryConnection>();
builder.Services.AddScoped<ITrabajadorService, TrabajadorService>();
builder.Services.AddScoped<ILocationService, LocationService>();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

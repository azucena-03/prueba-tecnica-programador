using FluentValidation;
using FluentValidation.AspNetCore;
using TrabajadoresPrueba.Models;
using TrabajadoresPrueba.Persistence;
using TrabajadoresPrueba.Repositories.Abstract;
using TrabajadoresPrueba.Repositories.Implementation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddOptions();
builder.Services.Configure<ConnectionConfiguration>(builder.Configuration.GetSection("ConnectionStrings"));

builder.Services.AddTransient<IFactoryConnection, FactoryConnection>();
builder.Services.AddScoped<ITrabajadorService, TrabajadorService>();
builder.Services.AddScoped<ILocationService, LocationService>();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<TrabajadorModelValidator>();

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
    pattern: "{controller=Trabajador}/{action=TrabajadorList}/{id?}");

app.Run();

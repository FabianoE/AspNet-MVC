using Microsoft.EntityFrameworkCore;
using MVC.Repositories.Data;
using MVC.Repositories.Repository;
using MVC.Repositories.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(context => context.UseNpgsql("Host=localhost;Port=5432;Pooling=true;Database=Cadastro;User Id=postgres;Password=123;"));
builder.Services.AddScoped<IContatoRepository, ContatoRepository>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
